using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;
using SolidWorksTools;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using CustomEnums;

namespace DGTesting {
    public class ISpurMF : MFBase, ISwComFeature {
        public new PMPage page;

        #region COM Register
        [ComRegisterFunction]
        public static void RegisterFunction(Type t) {
        }
        [ComUnregisterFunction]
        public static void UnregisterFunction(Type t) {
        }
        #endregion

        public override dynamic Edit(ISldWorks app, object modelDoc, object feature) {
            page = new PMPage(app);
            page.feature = (Feature)feature;
            page.Edit();
            return null;
        }

        public override dynamic Regenerate(ISldWorks app, object modelDoc, object feature) {
            MacroFeatureData data = (feature as Feature).GetDefinition();
            ModelDoc2 doc = (ModelDoc2)modelDoc;
            SelectionMgr slMgr = doc.SelectionManager;
            SketchManager skMgr = doc.SketchManager;
            
            data.GetIntegerByName("Ignore", out int ignore);
            if (ignore == 1) return ((PartDoc)modelDoc).GetBodies2((int)swBodyType_e.swAllBodies, false);

            data.GetIntegerByName("New", out int create);
            if (create == 1) {
                data.GetStringByName("OPNum", out string num);
                data.GetStringByName("OPType", out string op);
                data.GetIntegerByName("iFace", out int iFace);
                data.GetIntegerByName("iLine", out int iLine);
                data.GetIntegerByName("iPoint", out int iPoint);

                Face2 face = slMgr.GetSelectedObject6(iFace, -1);
                SketchLine line = slMgr.GetSelectedObject6(iLine, -1);
                SketchSegment seg = line as SketchSegment;
                SketchPoint point = slMgr.GetSelectedObject6(iPoint, -1);

                Debug.WriteLine("");
                Debug.WriteLine(slMgr.GetSelectedObjectCount2(-1));

                doc.ClearSelection2(true);
                (face as Entity).Select(false);
                doc.InsertSketch2(false);

                doc.ClearSelection2(true);
                MathPoint pnt = app.GetMathUtility().CreatePoint(new[] { 0, 0, 0 });

                SketchBlockDefinition def = skMgr.MakeSketchBlockFromFile(pnt, Blocks.Internal, false, 1, 0);
                SketchBlockInstance inst = def.GetInstances()[0];
                Feature feat = (Feature)inst.GetSketch();

                doc.InsertSketch2(true);
                ((Feature)feature).MakeSubFeature(feat);

                inst.Name = num + " BLOCK1";
                def.GetFeature().Name = num + " BLOCK1";
                feat.Name = num + " SKETCH1";

                ((Feature)feature).Name = num + " " + op;
                data.SetIntegerByName("New", 0);
                data.SetIntegerByName("Ignore", 1);
            }

            return ((PartDoc)modelDoc).GetBodies2((int)swBodyType_e.swAllBodies, false);
        }

        public override dynamic Security(ISldWorks app, object modelDoc, object feature) {
            return base.Security(app, modelDoc, feature);
        }

        public ISpurMF() : base() {
        }

        public class PMPage : IPMPage {
            public static bool create = true;
            public PageHandler handler;

            #region Groups
            public GroupBox Operation;
            public GroupBox Involute;
            public GroupBox Shape;
            public GroupBox Fillet;
            public GroupBox Center;
            #endregion

            public PMPage(ISldWorks app) : base(app) {
                handler = new PageHandler(this);
                page = app.CreatePropertyManagerPage("Internal Spline",
                    (int)(PMButtons.OkayButton | PMButtons.CancelButton), handler, 0);
                
                Operation = AddGroup("Operation", (int)(PMGroupOptions.Visible | PMGroupOptions.Expanded));
                Involute = AddGroup("Involute", (int)(PMGroupOptions.Visible | PMGroupOptions.Expanded));
                Shape = AddGroup("Form Definition", (int)(PMGroupOptions.Visible | PMGroupOptions.Expanded));
                Fillet = AddGroup("Root Fillet", (int)(PMGroupOptions.Visible | PMGroupOptions.Checkbox));
                Center = AddGroup("Centerline", (int)(PMGroupOptions.Visible | PMGroupOptions.Checkbox));

                #region Operation
                Operation["No"] = Operation.AddControl<PageTextbox>("", ControlAlign.Left,
                        (short)(ControlOptions.Enabled | ControlOptions.Visible | ControlOptions.Tight), "OP Number");
                Operation["No"].Text = "OP #";

                Operation["Type"] = Operation.AddControl<PageCombobox>("", ControlAlign.Left,
                        (short)(ControlOptions.Enabled | ControlOptions.Visible | ControlOptions.Tight), "OP Type");
                Operation["Type"].AddItems(new string[] { "SHAPE", "BROACH", "SPLINE GRIND" });
                Operation["Type"].Width = 60;
                Operation["No"].Width = 40;
                Operation["Type"].Top = 0;
                Operation["No"].Top = 0;
                Operation["Type"].Left = 45;
                #endregion

                #region Involute
                Involute["P"] = Involute.AddControl<PageCombobox>("", ControlAlign.Indent,
                        (short)(ControlOptions.Enabled | ControlOptions.Visible | ControlOptions.Tight), "Pitch");
                Involute["P"].SetStandardPictureLabel((int)BitmapLabels.LinearDistance);
                Involute["P"].AddItems(new string[] { "2.5/5", "3/6", "4/8", "5/10", "6/12", "8/16", "10/20", "12/24", "16/32", "20/40", "24/48", "32/64" });

                Involute["N"] = Involute.AddControl<PageNumberbox>("", ControlAlign.Indent,
                        (short)(ControlOptions.Enabled | ControlOptions.Visible | ControlOptions.Tight), "Number of Teeth");
                Involute["N"].SetStandardPictureLabel((int)BitmapLabels.CircularPattern);
                Involute["N"].DisplayedUnit = NumBoxType.UnitlessInteger;
                Involute["N"].Style = (int)swPropMgrPageNumberBoxStyle_e.swPropMgrPageNumberBoxStyle_ComboEditBox;
                Involute["N"].AddItems(new string[] { "Number of Teeth" });

                Involute["PA"] = Involute.AddControl<PageCombobox>("", ControlAlign.Indent,
                        (short)(ControlOptions.Enabled | ControlOptions.Visible | ControlOptions.Tight), "Pressure Angle");
                Involute["PA"].SetStandardPictureLabel((int)BitmapLabels.AngularDistance);
                Involute["PA"].AddItems(new string[] { "30°", "37.5°", "45°" });

                Involute["CSW"] = Involute.AddControl<PageNumberbox>("", ControlAlign.Indent,
                        (short)(ControlOptions.Enabled | ControlOptions.Visible | ControlOptions.Tight), "CSW at Pitch Diameter");
                Involute["CSW"].SetStandardPictureLabel((int)BitmapLabels.LinearDistance);
                Involute["CSW"].DisplayedUnit = NumBoxType.Length;
                Involute["CSW"].Style = (int)swPropMgrPageNumberBoxStyle_e.swPropMgrPageNumberBoxStyle_ComboEditBox;
                Involute["CSW"].AddItems(new string[] { "CSW at Pitch Diameter" });
                #endregion

                #region Form Definition
                Shape["Face"] = Shape.AddControl<PageSelection>("", ControlAlign.Indent,
                        (short)(ControlOptions.Enabled | ControlOptions.Visible | ControlOptions.Tight), "Plane or Face");
                Shape["Face"].SetStandardPictureLabel((int)BitmapLabels.SelectFace);
                Shape["Face"].SetSelectionFilters(new[] { swSelectType_e.swSelFACES, swSelectType_e.swSelDATUMPLANES });
                Shape["Face"].SingleEntityOnly = true;

                Shape["Root"] = Shape.AddControl<PageNumberbox>("", ControlAlign.Indent,
                        (short)(ControlOptions.Enabled | ControlOptions.Visible | ControlOptions.Tight), "Root Diameter");
                Shape["Root"].SetStandardPictureLabel((int)BitmapLabels.Diameter);
                Shape["Root"].DisplayedUnit = NumBoxType.Length;
                Shape["Root"].Style = (int)swPropMgrPageNumberBoxStyle_e.swPropMgrPageNumberBoxStyle_ComboEditBox;
                Shape["Root"].AddItems(new string[] { "Root Diameter" });

                Shape["Form"] = Shape.AddControl<PageNumberbox>("", ControlAlign.Indent,
                        (short)(ControlOptions.Enabled | ControlOptions.Visible | ControlOptions.Tight), "Form Diameter");
                Shape["Form"].SetStandardPictureLabel((int)BitmapLabels.Diameter);
                Shape["Form"].DisplayedUnit = NumBoxType.Length;
                Shape["Form"].Style = (int)swPropMgrPageNumberBoxStyle_e.swPropMgrPageNumberBoxStyle_ComboEditBox;
                Shape["Form"].AddItems(new string[] { "Form Diameter" });
                #endregion

                #region Root Radius
                Fillet["Full"] = Fillet.AddControl<PageCheckbox>("Full Fillet", ControlAlign.Left,
                        (short)(ControlOptions.Enabled | ControlOptions.Visible | ControlOptions.Tight), "Full Fillet");

                Fillet["Radius"] = Fillet.AddControl<PageNumberbox>("", ControlAlign.Indent,
                        (short)(ControlOptions.Enabled | ControlOptions.Visible | ControlOptions.Tight), "Fillet Radius");
                Fillet["Radius"].SetStandardPictureLabel((int)BitmapLabels.Radius);
                Fillet["Radius"].DisplayedUnit = NumBoxType.Length;
                Fillet["Radius"].Style = (int)swPropMgrPageNumberBoxStyle_e.swPropMgrPageNumberBoxStyle_ComboEditBox;
                Fillet["Radius"].AddItems(new string[] { "Fillet Radius" });
                #endregion

                #region Center
                Center["Line"] = Center.AddControl<PageSelection>("", ControlAlign.Indent,
                        (short)(ControlOptions.Enabled | ControlOptions.Visible | ControlOptions.Tight), "Center Line");
                Center["Line"].SetStandardPictureLabel((int)BitmapLabels.AngularDistance);
                Center["Line"].SetSelectionFilters(new[] { swSelectType_e.swSelEXTSKETCHSEGS });
                Center["Line"].SingleEntityOnly = true;

                Center["Point"] = Center.AddControl<PageSelection>("", ControlAlign.Indent,
                        (short)(ControlOptions.Enabled | ControlOptions.Visible | ControlOptions.Tight), "Center Point");
                Center["Point"].SetStandardPictureLabel((int)BitmapLabels.SelectVertex);
                Center["Point"].SetSelectionFilters(new[] { swSelectType_e.swSelEXTSKETCHPOINTS });
                Center["Point"].SingleEntityOnly = true;
                #endregion
            }
            public void Show() {
                page.Show();
                Involute["N"].CurrentSelection = 0;
                Involute["PA"].CurrentSelection = 0;
                Involute["CSW"].CurrentSelection = 0;
                Shape["Root"].CurrentSelection = 0;
                Shape["Form"].CurrentSelection = 0;
                Fillet["Radius"].CurrentSelection = 0;
            }
            public void Edit() {
                Shape["Face"].Enabled = false;
                Center["Line"].Enabled = false;
                Center["Point"].Enabled = false;
                page.Show();
            }
        }

        public class PageHandler : IPMPage.IPMHandler {
            public new PMPage parent;

            public PageHandler(PMPage parent) : base(parent) {
                this.parent = parent;
            }

            public override void OnClose(int Reason) {
                if (Reason == (int)PMCloseReason.Okay) {
                    IMFData data = new IMFData();
                    data["iFace"] = parent.Shape["Face"].Index[0];
                    data["iLine"] = parent.Center["Line"].Index[0];
                    data["iPoint"] = parent.Center["Point"].Index[0];
                    
                    data["OPNum"] = parent.Operation["No"].Text;
                    data["OPType"] = parent.Operation["Type"].Text;
                    data["Ignore"] = (int)0;
                    data["New"] = (int)1;

                    if (parent.feature == null) {
                        FeatureManager mgr = parent.doc.FeatureManager;
                        dynamic list = ((PartDoc)parent.doc).GetBodies2((int)swBodyType_e.swAllBodies, false);
                        
                        parent.feature = mgr.InsertMacroFeature3("Internal Spur", "DGTesting.InternalSpurFeature", null,
                            data.names, data.types, data.values, null, null, list, Icons.Internal, (int)swMacroFeatureOptions_e.swMacroFeatureByDefault);
                    }
                }
            }
            public override void OnCheckboxCheck(PageCheckbox checkbox) {
                if (checkbox == parent.Fillet["Full"]) {
                    parent.Fillet["Radius"].Enabled = !checkbox.Checked;
                }
            }
            public override bool OnSubmitSelection(PageSelection select, object Selection, int SelType, ref string ItemText) {
                SelectionMgr slMgr = parent.doc.SelectionManager;
                SelectData slData = slMgr.CreateSelectData();
                slData.Mark = select.Mark;
                slMgr.AddSelectionListObject(Selection, slData);
                if (select == parent.Center["Line"]) {
                    if ((Selection as SketchSegment).GetType() != (int)swSketchSegments_e.swSketchLINE) {
                        select.ShowBubbleTooltip("Invalid Input", "Not a Line", "");
                        return false;
                    }
                } else if (select == parent.Shape["Face"]) {
                    if (!(Selection as Face2).GetSurface().IsPlane()) {
                        select.ShowBubbleTooltip("Invalid Input", "Not Planar Surface", "");
                        return false;
                    }
                }
                return true;
            }
        }
    }
}