using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;
using SolidWorksTools;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using CustomEnums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace DGTesting {
    public class MFBase : ISwComFeature {
        public IPMPage page;
        public ISldWorks app;
        public MFBase() {
        }
        dynamic ISwComFeature.Edit(object app, object modelDoc, object feature) {
            this.app = (ISldWorks)app;
            return Edit(this.app, modelDoc, feature);
        }

        dynamic ISwComFeature.Regenerate(object app, object modelDoc, object feature) {
            this.app = (ISldWorks)app;
            return Regenerate(this.app, modelDoc, feature);
        }

        dynamic ISwComFeature.Security(object app, object modelDoc, object feature) {
            this.app = (ISldWorks)app;
            return Security(this.app, modelDoc, feature);
        }

        public virtual dynamic Edit(ISldWorks app, object modelDoc, object feature) {
            return null;
        }

        public virtual dynamic Regenerate(ISldWorks app, object modelDoc, object feature) {
            return null;
        }

        public virtual dynamic Security(ISldWorks app, object modelDoc, object feature) {
            return swMacroFeatureSecurityOptions_e.swMacroFeatureSecurityByDefault;
        }
    }

    public class IPMPage {
        public PropertyManagerPage2 page;
        public ISldWorks app;
        public ModelDoc2 doc;
        public Feature feature;

        public int idCounter = 1;
        public int mCounter = 1;
        public Dictionary<int, PageElement> elements
            = new Dictionary<int, PageElement>();
        public IPMPage(ISldWorks app) {
            this.app = app;
            doc = app.ActiveDoc;
        }
        public GroupBox AddGroup(string caption, int options) {
            return new GroupBox(this, caption, options);
        }
        public class IPMHandler : PropertyManagerPage2Handler9 {
            public IPMPage parent = null;
            public IPMHandler(IPMPage parent) {
                this.parent = parent;
            }
            #region Virtuals
            public virtual void AfterActivation() {

            }
            public virtual void OnClose(int Reason) {

            }
            public virtual void AfterClose() {

            }
            public virtual bool OnHelp() {
                return true;
            }
            public virtual bool OnPreviousPage() {
                return true;
            }
            public virtual bool OnNextPage() {
                return true;
            }
            public virtual bool OnPreview() {
                return true;
            }
            public virtual void OnWhatsNew() {

            }
            public virtual void OnUndo() {

            }
            public virtual void OnRedo() {

            }
            public virtual bool OnTabClicked(int Id) {
                return true;
            }
            public virtual void OnGroupExpand(int Id, bool Expanded) {
                OnGroupExpand((GroupBox)parent.elements[Id]);
            }
            public virtual void OnGroupExpand(GroupBox group) {

            }
            public virtual void OnGroupCheck(int Id, bool Checked) {
                OnGroupCheck((GroupBox)parent.elements[Id]);
            }
            public virtual void OnGroupCheck(GroupBox group) {

            }
            public virtual void OnCheckboxCheck(int Id, bool Checked) {
                OnCheckboxCheck((PageCheckbox)parent.elements[Id]);
            }
            public virtual void OnCheckboxCheck(PageCheckbox checkbox) {

            }
            public virtual void OnOptionCheck(int Id) {
                OnOptionCheck((PageOption)parent.elements[Id]);
            }
            public virtual void OnOptionCheck(PageOption option) {

            }
            public virtual void OnButtonPress(int Id) {
                OnButtonPress((PageButton)parent.elements[Id]);
            }
            public virtual void OnButtonPress(PageButton button) {

            }
            public virtual void OnTextboxChanged(int Id, string Text) {
                OnTextboxChanged((PageTextbox)parent.elements[Id]);
            }
            public virtual void OnTextboxChanged(PageTextbox textbox) {

            }
            public virtual void OnNumberboxChanged(int Id, double Value) {
                OnNumberboxChanged((PageNumberbox)parent.elements[Id]);
            }
            public virtual void OnNumberboxChanged(PageNumberbox numberbox) {

            }
            public virtual void OnComboboxEditChanged(int Id, string Text) {
                OnComboboxEditChanged((PageCombobox)parent.elements[Id]);
            }
            public virtual void OnComboboxEditChanged(PageCombobox combobox) {

            }
            public virtual void OnComboboxSelectionChanged(int Id, int Item) {
                OnComboboxSelectionChanged((PageCombobox)parent.elements[Id]);
            }
            public virtual void OnComboboxSelectionChanged(PageCombobox combobox) {

            }
            public virtual void OnListboxSelectionChanged(int Id, int Item) {
                OnListboxSelectionChanged(parent.elements[Id]);
            }
            public virtual void OnListboxSelectionChanged(dynamic listbox) {

            }
            public virtual void OnSelectionboxFocusChanged(int Id) {
                OnSelectionboxFocusChanged((PageSelection)parent.elements[Id]);
            }
            public virtual void OnSelectionboxFocusChanged(PageSelection select) {

            }
            public virtual void OnSelectionboxListChanged(int Id, int Count) {
                OnSelectionboxListChanged((PageSelection)parent.elements[Id]);
            }
            public virtual void OnSelectionboxListChanged(PageSelection select) {

            }
            public virtual void OnSelectionboxCalloutCreated(int Id) {
                OnSelectionboxCalloutCreated((PageSelection)parent.elements[Id]);
            }
            public virtual void OnSelectionboxCalloutCreated(PageSelection select) {

            }
            public virtual void OnSelectionboxCalloutDestroyed(int Id) {
                OnSelectionboxCalloutDestroyed((PageSelection)parent.elements[Id]);
            }
            public virtual void OnSelectionboxCalloutDestroyed(PageSelection select) {

            }
            public virtual bool OnSubmitSelection(int Id, object Selection, int SelType, ref string ItemText) {
                return OnSubmitSelection((PageSelection)parent.elements[Id], Selection, SelType, ref ItemText);
            }
            public virtual bool OnSubmitSelection(PageSelection select, object Selection, int SelType, ref string ItemText) {
                return true;
            }
            public virtual int OnActiveXControlCreated(int Id, bool Status) {
                return OnActiveXControlCreated((PageActiveX)parent.elements[Id], Status);
            }
            public virtual int OnActiveXControlCreated(PageActiveX activex, bool Status) {
                return (int)swHandleActiveXCreationFailure_e.swHandleActiveXCreationFailure_Continue;
            }
            public virtual void OnSliderPositionChanged(int Id, double Value) {
                OnSliderPositionChanged((PageSlider)parent.elements[Id], Value);
            }
            public virtual void OnSliderPositionChanged(PageSlider slider, double Value) {

            }
            public virtual void OnSliderTrackingCompleted(int Id, double Value) {
                OnSliderTrackingCompleted((PageSlider)parent.elements[Id], Value);
            }
            public virtual void OnSliderTrackingCompleted(PageSlider slider, double Value) {

            }
            public virtual bool OnKeystroke(int Wparam, int Message, int Lparam, int Id) {
                return true;
            }
            public virtual void OnPopupMenuItem(int Id) {

            }
            public virtual void OnPopupMenuItemUpdate(int Id, ref int retval) {

            }
            public virtual void OnGainedFocus(int Id) {
                OnGainedFocus((PageControl)parent.elements[Id]);
            }
            public virtual void OnGainedFocus(PageControl control) {

            }
            public virtual void OnLostFocus(int Id) {
                OnLostFocus((PageControl)parent.elements[Id]);
            }
            public virtual void OnLostFocus(PageControl control) {

            }
            public virtual int OnWindowFromHandleControlCreated(int Id, bool Status) {
                return (int)swHandleWindowFromHandleCreationFailure_e.swHandleWindowFromHandleCreationFailure_Continue;
            }
            public virtual void OnListboxRMBUp(int Id, int PosX, int PosY) {
                OnListboxRMBUp(parent.elements[Id], PosX, PosY);
            }
            public virtual void OnListboxRMBUp(dynamic listbox, int PosX, int PosY) {

            }
            public virtual void OnNumberBoxTrackingCompleted(int Id, double Value) {
                OnNumberBoxTrackingCompleted((PageNumberbox)parent.elements[Id], Value);
            }
            public virtual void OnNumberBoxTrackingCompleted(PageNumberbox numberbox, double Value) {

            }
            #endregion
        }
    }
    public class IMFData {
        private Dictionary<string, dynamic> _data
            = new Dictionary<string, dynamic>();

        public dynamic this[string name] {
            get => _data[name];
            set => _data[name] = value;
        }

        public string[] names {
            get => _data.Keys.ToArray();
        }
        public int[] types {
            get => (from val in _data.Values.ToArray() select (
                val is string ? (int)MacroFeatureDataType.String :
                val is int ? (int)MacroFeatureDataType.Integer :
                (int)MacroFeatureDataType.Double
            )).ToArray();
        }
        public string[] values {
            get => (from val in _data.Values.ToArray() select (
                Convert.ToString(val) as string
            )).ToArray();
        }
    }
    public class GroupBox : PageElement {
        private Dictionary<string, dynamic> controls
            = new Dictionary<string, dynamic>();
        public PropertyManagerPageGroup group;
        public IPMPage parent;
        public GroupBox(IPMPage page, string caption, int options) {
            parent = page;
            group = page.page.AddGroupBox(parent.idCounter, caption, options);
            ID = parent.idCounter;
            parent.idCounter++;
            parent.elements.Add(ID, this);
        }
        public T AddControl<T>(string caption, ControlAlign align, int options, string tip) where T : PageControl, new() {
            object[] arr = typeof(T).GetCustomAttributes(true);
            return Activator.CreateInstance(typeof(T), this, ((IControlType)arr[0]).type, caption, align, options, tip) as T;
        }
        public bool Visible { get => group.Visible; set => group.Visible = value; }
        public bool Expanded { get => group.Expanded; set => group.Expanded = value; }
        public bool Checked { get => group.Checked; set => group.Checked = value; }
        public string Caption { get => group.Caption; set => group.Caption = value; }
        public int BackgroundColor { get => group.BackgroundColor; set => group.BackgroundColor = value; }
        public dynamic this[string name] {
            get => controls[name];
            set => controls.Add(name, value);
        }
    }
    [AttributeUsage(AttributeTargets.All)]

    public class IControlType : System.Attribute {
        private ControlType _type;
        public IControlType(ControlType type) {
            _type = type;
        }
        public virtual ControlType type { get => _type; }
    }
    
    [IControlType(0)]
    public class PageControl : PageElement {
        public PropertyManagerPageControl control;
        public IPMPage parent;
        public GroupBox group;
        public PageLabel label;
        public const ControlType type = 0;
        public PageControl() { }
        public PageControl(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) {
            parent = group.parent;
            control = group.group.AddControl2(parent.idCounter, (short)type, caption, (short)align, options, tip);
            ID = parent.idCounter;
            parent.idCounter++;
            parent.elements.Add(ID, this);
        }
        public static bool operator ==(PageControl a, PageControl b) {
            return a.ID == b.ID;
        }
        public static bool operator !=(PageControl a, PageControl b) {
            return a.ID != b.ID;
        }
        public override bool Equals(object obj) {
            if (obj.GetType() == typeof(PageControl)) {
                return ID == ((PageControl)obj).ID;
            } else {
                return base.Equals(obj);
            }
        }

        public bool SetStandardPictureLabel(int Bitmap) {
            return control.SetStandardPictureLabel(Bitmap);
        }

        public bool SetPictureLabelByName(string ColorBitmap, string MaskBitmap) {
            return control.SetPictureLabelByName(ColorBitmap, MaskBitmap);
        }

        public void ShowBubbleTooltip(string Title, string Message, string BmpFile) {
            control.ShowBubbleTooltip(Title, Message, BmpFile);
        }
        public bool Visible { get => control.Visible; set => control.Visible = value; }
        public bool Enabled { get => control.Enabled; set => control.Enabled = value; }
        public string Tip { get => control.Tip; set => control.Tip = value; }
        public short Left { get => control.Left; set => control.Left = value; }
        public short Width { get => control.Width; set => control.Width = value; }
        public short Top { get => control.Top; set => control.Top = value; }
        public int TextColor { get => control.TextColor; set => control.TextColor = value; }
        public int BackgroundColor { get => control.BackgroundColor; set => control.BackgroundColor = value; }
        public int OptionsForResize { get => control.OptionsForResize; set => control.OptionsForResize = value; }
    }
    [IControlType(ControlType.ActiveX)]
    public class PageActiveX : PageControl {
        private PropertyManagerPageActiveX activex;
        public const ControlType type = ControlType.ActiveX;
        public PageActiveX(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) : base(group, type, caption, align, options, tip) {
            activex = (PropertyManagerPageActiveX)control;
        }
        public PageActiveX() { }
        public bool SetClass(string ClassID, string LicenseKey) {
            return activex.SetClass(ClassID, LicenseKey);
        }
        public dynamic GetControl() {
            return activex.GetControl();
        }
        public dynamic IGetControl() {
            return activex.IGetControl();
        }
        public short Height { get => activex.Height; set => activex.Height = value; }
    }
    [IControlType(ControlType.Bitmap)]
    public class PageBitmap : PageControl {
        private PropertyManagerPageBitmap bitmap;
        public PageBitmap(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) : base(group, type, caption, align, options, tip) {
            bitmap = (PropertyManagerPageBitmap)control;
        }
        public PageBitmap() { }
        public bool SetStandardBitmap(int Bitmap) {
            return bitmap.SetStandardBitmap(Bitmap);
        }
        public bool SetBitmapByName(string ColorBitmap, string MaskBitmap) {
            return bitmap.SetBitmapByName(ColorBitmap, MaskBitmap);
        }
    }
    [IControlType(ControlType.BitmapButton)]
    public class PageBitmapButton : PageControl, PropertyManagerPageBitmapButton {
        private PropertyManagerPageBitmapButton button;
        public PageBitmapButton(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) : base(group, type, caption, align, options, tip) {
            button = (PropertyManagerPageBitmapButton)control;
        }
        public PageBitmapButton() { }
        public bool SetBitmaps(int ModuleHandle, int BitmapUp, int BitmapDown, int BitmapDisabled) {
            return button.SetBitmaps(ModuleHandle, BitmapUp, BitmapDown, BitmapDisabled);
        }
        public bool SetStandardBitmaps(int Bitmap) {
            return button.SetStandardBitmaps(Bitmap);
        }

        public bool SetBitmapsByName(string BitmapUp, string BitmapDown, string BitmapDisabled) {
            return button.SetBitmapsByName(BitmapUp, BitmapDown, BitmapDisabled);
        }

        public bool SetBitmapsByName2(string BitmapOrig, string BitmapMaskOrig) {
            return button.SetBitmapsByName2(BitmapOrig, BitmapMaskOrig);
        }

        public bool SetBitmapsx64(long ModuleHandle, int BitmapUp, int BitmapDown, int BitmapDisabled) {
            return button.SetBitmapsx64(ModuleHandle, BitmapUp, BitmapDown, BitmapDisabled);
        }

        public bool SetBitmapsByName3(object ImageList, object MaskImageList) {
            return button.SetBitmapsByName3(ImageList, MaskImageList);
        }

        public bool Checked { get => button.Checked; set => button.Checked = value; }
        public bool IsCheckable { get => button.IsCheckable; set => button.IsCheckable = value; }
    }
    [IControlType(ControlType.Button)]
    public class PageButton : PageControl {
        public PropertyManagerPageButton button;
        public PageButton(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) : base(group, type, caption, align, options, tip) {
            button = (PropertyManagerPageButton)control;
        }
        public PageButton() { }
        public string Caption { get => button.Caption; set => button.Caption = value; }
    }
    [IControlType(ControlType.Checkbox)]
    public class PageCheckbox : PageControl {
        private PropertyManagerPageCheckbox checkbox;
        public PageCheckbox(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) : base(group, type, caption, align, options, tip) {
            checkbox = (PropertyManagerPageCheckbox)control;
        }
        public PageCheckbox() { }
        public bool Checked { get => checkbox.Checked; set => checkbox.Checked = value; }
        public string Caption { get => checkbox.Caption; set => checkbox.Caption = value; }
        public int State { get => checkbox.State; set => checkbox.State = value; }
    }
    [IControlType(ControlType.Combobox)]
    public class PageCombobox : PageControl {
        private PropertyManagerPageCombobox combobox;
        private List<string> Items = new List<string>();
        public PageCombobox(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) : base(group, type, caption, align, options, tip) {
            combobox = (PropertyManagerPageCombobox)control;
            ItemText = new _ItemText(this);
        }
        public PageCombobox() { }
        public void AddItems(string[] list) {
            Items.AddRange(list);
            combobox.AddItems(list);
        }
        public void Clear() {
            Items.Clear();
        }
        public void InsertItem(string item) {
            Items.Add(item);
            combobox.AddItems(item);
        }
        public void DeleteItem(string item) {
            combobox.DeleteItem((short)Items.IndexOf(item));
            Items.Remove(item);
        }
        public short CurrentSelection { get => combobox.CurrentSelection; set => combobox.CurrentSelection = value; }
        public short Height { get => combobox.Height; set => combobox.Height = value; }
        public int Style { get => combobox.Style; set => combobox.Style = value; }
        public string Text { get => combobox.EditText; set => combobox.EditText = value; }
        public class _ItemText {
            PageCombobox parent;
            public _ItemText(PageCombobox parent) { this.parent = parent; }
            public string this[short Item] {
                get => parent.combobox.ItemText[Item];
            }
        }
        public _ItemText ItemText;
    }
    [IControlType(ControlType.Label)]
    public class PageLabel : PageControl {
        public PropertyManagerPageLabel label;
        public PageLabel(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) : base(group, type, caption, align, options, tip) {
            label = (PropertyManagerPageLabel)control;
            Bold = new _Bold(this);
            Italic = new _Italic(this);
            Underline = new _Underline(this);
            Font = new _Font(this);
            SizeRatio = new _SizeRatio(this);
            LineOffset = new _LineOffset(this);
            CharacterColor = new _CharacterColor(this);
            CharacterBackgroundColor = new _CharacterBackgroundColor(this);
        }
        public PageLabel() { }
        public string Caption { get => label.Caption; set => throw new NotImplementedException(); }
        public int Style { get => label.Style; set => throw new NotImplementedException(); }
        public short Height { get => label.Height; set => throw new NotImplementedException(); }
        public class _Bold {
            PageLabel parent;
            public _Bold(PageLabel parent) { this.parent = parent; }
            public bool this[short startChar, short endChar] {
                get => parent.label.Bold[startChar, endChar];
                set => parent.label.Bold[startChar, endChar] = value;
            }
        }
        public _Bold Bold;
        public class _Italic {
            PageLabel parent;
            public _Italic(PageLabel parent) { this.parent = parent; }
            public bool this[short startChar, short endChar] {
                get => parent.label.Italic[startChar, endChar];
                set => parent.label.Italic[startChar, endChar] = value;
            }
        }
        public _Italic Italic;
        public class _Underline {
            PageLabel parent;
            public _Underline(PageLabel parent) { this.parent = parent; }
            public int this[short startChar, short endChar] {
                get => parent.label.Underline[startChar, endChar];
                set => parent.label.Underline[startChar, endChar] = value;
            }
        }
        public _Underline Underline;
        public class _Font {
            PageLabel parent;
            public _Font(PageLabel parent) { this.parent = parent; }
            public string this[short startChar, short endChar] {
                get => parent.label.Font[startChar, endChar];
                set => parent.label.Font[startChar, endChar] = value;
            }
        }
        public _Font Font;
        public class _SizeRatio {
            PageLabel parent;
            public _SizeRatio(PageLabel parent) { this.parent = parent; }
            public double this[short startChar, short endChar] {
                get => parent.label.SizeRatio[startChar, endChar];
                set => parent.label.SizeRatio[startChar, endChar] = value;
            }
        }
        public _SizeRatio SizeRatio;
        public class _LineOffset {
            PageLabel parent;
            public _LineOffset(PageLabel parent) { this.parent = parent; }
            public double this[short startChar, short endChar] {
                get => parent.label.LineOffset[startChar, endChar];
                set => parent.label.LineOffset[startChar, endChar] = value;
            }
        }
        public _LineOffset LineOffset;
        public class _CharacterColor {
            PageLabel parent;
            public _CharacterColor(PageLabel parent) { this.parent = parent; }
            public int this[short startChar, short endChar] {
                get => parent.label.CharacterColor[startChar, endChar];
                set => parent.label.CharacterColor[startChar, endChar] = value;
            }
        }
        public _CharacterColor CharacterColor;
        public class _CharacterBackgroundColor {
            PageLabel parent;
            public _CharacterBackgroundColor(PageLabel parent) { this.parent = parent; }
            public int this[short startChar, short endChar] {
                get => parent.label.CharacterBackgroundColor[startChar, endChar];
                set => parent.label.CharacterBackgroundColor[startChar, endChar] = value;
            }
        }
        public _CharacterBackgroundColor CharacterBackgroundColor;
    }
    [IControlType(ControlType.Listbox)]
    public class PageListbox : PageControl {
        private PropertyManagerPageListbox listbox;
        private List<string> Items = new List<string>();
        public PageListbox(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) : base(group, type, caption, align, options, tip) {
            listbox = (PropertyManagerPageListbox)control;
            ItemText = new _ItemText(this);
        }
        public PageListbox() { }
        public void AddItems(string[] list) {
            listbox.AddItems(list);
            Items.AddRange(list);
        }
        public void Clear() {
            listbox.Clear();
            Items.Clear();
        }
        public short InsertItem(short Item, string Text) {
            Items.Insert(Item, Text);
            return listbox.InsertItem(Item, Text);
        }
        public short DeleteItem(short Item) {
            Items.RemoveAt(Item);
            return listbox.DeleteItem(Item);
        }
        public int GetSelectedItemsCount() {
            return listbox.GetSelectedItemsCount();
        }
        public dynamic GetSelectedItems() {
            return from i in (listbox.GetSelectedItems() as short[]) select Items[i];
        }
        public bool SetSelectedItem(short Item, bool Selected) {
            return listbox.SetSelectedItem(Item, Selected);
        }
        public short CurrentSelection { get => listbox.CurrentSelection; set => listbox.CurrentSelection = value; }
        public short Height { get => listbox.Height; set => listbox.Height = value; }
        public class _ItemText {
            PageListbox parent;
            public _ItemText(PageListbox parent) { this.parent = parent; }
            public string this[short Item] {
                get => parent.listbox.ItemText[Item];
            }
        }
        public _ItemText ItemText;
        public int Style { get => listbox.Style; set => listbox.Style = value; }
        public int ItemCount { get => listbox.ItemCount; }
    }
    [IControlType(ControlType.Numberbox)]
    public class PageNumberbox : PageControl {
        public PropertyManagerPageNumberbox numberbox;
        private List<string> Items = new List<string>();
        public PageNumberbox(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) : base(group, type, caption, align, options, tip) {
            numberbox = (PropertyManagerPageNumberbox)control;
            ItemText = new _ItemText(this);
        }
        public PageNumberbox() { }
        public void SetRange(NumBoxType Units, double Minimum, double Maximum, double Increment, bool Inclusive) {
            numberbox.SetRange((int)Units, Minimum, Maximum, Increment, Inclusive);
        }
        public void AddItems(string[] list) {
            Items.AddRange(list);
            numberbox.AddItems(list);
        }
        public void Clear() {
            Items.Clear();
        }
        public void InsertItem(string item) {
            Items.Add(item);
            numberbox.AddItems(item);
        }
        public void DeleteItem(string item) {
            numberbox.DeleteItem((short)Items.IndexOf(item));
            Items.Remove(item);
        }
        public void SetRange2(NumBoxType Units, double Minimum, double Maximum, bool Inclusive, double Increment, double FastIncr, double SlowIncr) {
            numberbox.SetRange2((int)Units, Minimum, Maximum, Inclusive, Increment, FastIncr, SlowIncr);
        }
        public void SetSliderParameters(int PositionCount, int DivisionCount) {
            numberbox.SetSliderParameters(PositionCount, DivisionCount);
        }
        public double Value { get => numberbox.Value; set => numberbox.Value = value; }
        public int Style { get => numberbox.Style; set => numberbox.Style = value; }
        public short CurrentSelection { get => numberbox.CurrentSelection; set => numberbox.CurrentSelection = value; }
        public short Height { get => numberbox.Height; set => numberbox.Height = value; }
        public class _ItemText {
            PageNumberbox parent;
            public _ItemText(PageNumberbox parent) { this.parent = parent; }
            public string this[short Item] {
                get => parent.numberbox.ItemText[Item];
            }
        }
        public _ItemText ItemText;
        public string Text { get => numberbox.Text; }
        public NumBoxType DisplayedUnit { get => (NumBoxType)numberbox.DisplayedUnit; set => numberbox.DisplayedUnit = (int)value; }
    }
    [IControlType(ControlType.Option)]
    public class PageOption : PageControl {
        public PropertyManagerPageOption option;
        public PageOption(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) : base(group, type, caption, align, options, tip) {
            option = (PropertyManagerPageOption)control;
        }
        public PageOption() { }
        public bool Checked { get => option.Checked; set => option.Checked = value; }
        public string Caption { get => option.Caption; set => option.Caption = value; }
        public int Style { get => option.Style; set => option.Style = value; }
    }
    [IControlType(ControlType.Selectionbox)]
    public class PageSelection : PageControl {
        public PropertyManagerPageSelectionbox select;
        public PageSelection(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) : base(group, type, caption, align, options, tip) {
            select = (PropertyManagerPageSelectionbox)control;
            Index = new _Index(this);
            ItemText = new _ItemText(this);
            select.Mark = (int)Math.Pow(2, parent.mCounter);
            parent.mCounter++;
        }
        public PageSelection() { }
        public void SetSelectionFilters(object Filters) {
            select.SetSelectionFilters(Filters);
        }
        public bool GetSelectionFocus() {
            return select.GetSelectionFocus();
        }
        public void SetSelectionFocus() {
            select.SetSelectionFocus();
        }
        public bool SetSelectionColor(bool Special, int Color) {
            return select.SetSelectionColor(Special, Color);
        }
        public bool SetCalloutLabel(string Label) {
            return select.SetCalloutLabel(Label);
        }
        public bool AddMenuPopupItem(int ID, string ItemText, int DocumentType, string HintText) {
            return select.AddMenuPopupItem(ID, ItemText, DocumentType, HintText);
        }
        public int GetSelectedItemsCount() {
            return select.GetSelectedItemsCount();
        }
        public short[] GetSelectedItems() {
            return select.GetSelectedItems();
        }
        public bool SetSelectedItem(short Item, bool Selected) {
            return select.SetSelectedItem(Item, Selected);
        }
        public dynamic SelectItems(SelectionMgr mgr) {
            return from i in Enumerable.Range(0, ItemCount - 1) select mgr.GetSelectedObject5(Index[(short)i]);
        }
        public short Height { get => select.Height; set => select.Height = value; }
        public int Mark { get => select.Mark; set => select.Mark = value; }
        public bool SingleEntityOnly { get => select.SingleEntityOnly; set => select.SingleEntityOnly = value; }
        public Callout Callout { get => select.Callout; set => select.Callout = value; }
        public int Style { get => select.Style; set => select.Style = value; }
        public int ItemCount { get => select.ItemCount; }
        public int CurrentSelection { get => select.CurrentSelection; set => select.CurrentSelection = value; }
        public class _Index {
            PageSelection parent;
            public _Index(PageSelection parent) { this.parent = parent; }
            public int this[short Item] {
                get => parent.select.SelectionIndex[Item];
            }
        }
        public _Index Index;
        public class _ItemText {
            PageSelection parent;
            public _ItemText(PageSelection parent) { this.parent = parent; }
            public string this[short Item] {
                get => parent.select.ItemText[Item];
            }
        }
        public _ItemText ItemText;
        public bool AllowSelectInMultipleBoxes { get => select.AllowSelectInMultipleBoxes; set => select.AllowSelectInMultipleBoxes = value; }
        public bool AllowMultipleSelectOfSameEntity { get => select.AllowMultipleSelectOfSameEntity; set => select.AllowMultipleSelectOfSameEntity = value; }
        public bool EnableSelectIdenticalComponents { get => select.EnableSelectIdenticalComponents; set => select.EnableSelectIdenticalComponents = value; }
    }
    [IControlType(ControlType.Slider)]
    public class PageSlider : PageControl {
        private PropertyManagerPageSlider slider;
        public PageSlider(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) : base(group, type, caption, align, options, tip) {
            slider = (PropertyManagerPageSlider)control;
        }
        public PageSlider() { }
        public void GetRange(ref int Min, ref int Max) {
            slider.GetRange(ref Min, ref Max);
        }
        public bool SetRange(int Min, int Max) {
            return slider.SetRange(Min, Max);
        }
        public int Style { get => slider.Style; set => slider.Style = value; }
        public int Position { get => slider.Position; set => slider.Position = value; }
        public int TickFrequency { get => slider.TickFrequency; set => slider.TickFrequency = value; }
        public short Height { get => slider.Height; set => slider.Height = value; }
        public int LineSize { get => slider.LineSize; set => slider.LineSize = value; }
        public int PageSize { get => slider.PageSize; set => slider.PageSize = value; }
    }
    [IControlType(ControlType.Textbox)]
    public class PageTextbox : PageControl {
        public PropertyManagerPageTextbox textbox;
        public PageTextbox(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) : base(group, type, caption, align, options, tip) {
            textbox = (PropertyManagerPageTextbox)control;
        }
        public PageTextbox() { }
        public string Text { get => textbox.Text; set => textbox.Text = value; }
        public int Style { get => textbox.Style; set => textbox.Style = value; }
        public short Height { get => textbox.Height; set => textbox.Height = value; }
    }
    [IControlType(ControlType.WindowFromHandle)]
    public class PageWindow : PageControl, PropertyManagerPageWindowFromHandle {
        public PropertyManagerPageWindowFromHandle window;
        public PageWindow(GroupBox group, ControlType type, string caption, ControlAlign align, int options, string tip) : base(group, type, caption, align, options, tip) {
            window = (PropertyManagerPageWindowFromHandle)control;
        }
        public PageWindow() { }
        public bool SetWindowHandle(int WindowHandle) {
            return window.SetWindowHandle(WindowHandle);
        }
        public bool SetWindowHandlex64(long WindowHandle) {
            return window.SetWindowHandlex64(WindowHandle);
        }
        public int Height { get => window.Height; set => window.Height = value; }
    }
    public class PageElement {
        public int ID;
    }
}