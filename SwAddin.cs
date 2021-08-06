using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;
using SolidWorksTools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DGTesting {
    /// <summary>
    /// Summary description for DGTesting.
    /// </summary>
    [Guid("2C470B24-1723-442F-B4A5-272D5A7C3EF0"), ComVisible(true)]
    [SwAddin(
        Description = "DGTesting description",
        Title = "DGTesting",
        LoadAtStartup = true
    )]
    public class SwAddin : ISwAddin {
        #region Local Variables
        ISldWorks iSwApp = null;
        int addinID = 0;

        Hashtable openDocs = new Hashtable();
        SldWorks SwEventPtr = null;

        public const int mainCmdGroupID = 5;

        // Public Properties
        public ISldWorks SwApp {
            get { return iSwApp; }
        }

        public Hashtable OpenDocs {
            get { return openDocs; }
        }

        #endregion

        #region SolidWorks Registration
        [ComRegisterFunction]
        public static void RegisterFunction(Type t) {
            #region Get Custom Attribute: SwAddinAttribute
            SwAddinAttribute SWattr = null;
            Type type = typeof(SwAddin);

            foreach (System.Attribute attr in type.GetCustomAttributes(false)) {
                if (attr is SwAddinAttribute) {
                    SWattr = attr as SwAddinAttribute;
                    break;
                }
            }

            #endregion

            try {
                Microsoft.Win32.RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
                Microsoft.Win32.RegistryKey hkcu = Microsoft.Win32.Registry.CurrentUser;

                string keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID.ToString() + "}";
                Microsoft.Win32.RegistryKey addinkey;
                // addinkey = hklm.CreateSubKey(keyname);
                // addinkey.SetValue(null, 0);

                // addinkey.SetValue("Description", SWattr.Description);
                // addinkey.SetValue("Title", SWattr.Title);

                keyname = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID.ToString() + "}";
                addinkey = hkcu.CreateSubKey(keyname);
                addinkey.SetValue(null, Convert.ToInt32(SWattr.LoadAtStartup), Microsoft.Win32.RegistryValueKind.DWord);
            } catch (System.NullReferenceException nl) {
                Console.WriteLine("There was a problem registering this dll: SWattr is null. \n\"" + nl.Message + "\"");
                System.Windows.Forms.MessageBox.Show("There was a problem registering this dll: SWattr is null.\n\"" + nl.Message + "\"");
            } catch (System.Exception e) {
                Console.WriteLine(e.Message);

                System.Windows.Forms.MessageBox.Show("There was a problem registering the function: \n\"" + e.Message + "\"");
            }
        }

        [ComUnregisterFunction]
        public static void UnregisterFunction(Type t) {
            try {
                Microsoft.Win32.RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
                Microsoft.Win32.RegistryKey hkcu = Microsoft.Win32.Registry.CurrentUser;

                string keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID.ToString() + "}";
                // hklm.DeleteSubKey(keyname);

                keyname = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID.ToString() + "}";
                hkcu.DeleteSubKey(keyname);
            } catch (System.NullReferenceException nl) {
                Console.WriteLine("There was a problem unregistering this dll: " + nl.Message);
                System.Windows.Forms.MessageBox.Show("There was a problem unregistering this dll: \n\"" + nl.Message + "\"");
            } catch (System.Exception e) {
                Console.WriteLine("There was a problem unregistering this dll: " + e.Message);
                System.Windows.Forms.MessageBox.Show("There was a problem unregistering this dll: \n\"" + e.Message + "\"");
            }
        }

        #endregion

        #region ISwAddin Implementation
        public SwAddin() {

        }

        public bool ConnectToSW(object ThisSW, int cookie) {
            iSwApp = (ISldWorks)ThisSW;
            addinID = cookie;
            
            //Setup callbacks
            iSwApp.SetAddinCallbackInfo(0, this, addinID);

            SwEventPtr = (SldWorks)iSwApp;
            openDocs = new Hashtable();

            /*
            TestControl testControl = new TestControl();
            Form form = new Form()
            {
                Text = "Testing Dialog 2",
                WindowState = FormWindowState.Normal
            };

            form.Controls.Add(testControl);
            form.ClientSize = testControl.Size;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowDialog();
            */

            ICommandManager iCmdMgr = iSwApp.GetCommandManager(addinID);
            CommandGroup cmdGroup = iCmdMgr.CreateCommandGroup(mainCmdGroupID, "DGTesting", "DGTesting Commands", "", -1);

            cmdGroup.LargeMainIcon = "U:\\SWPLUGINS\\DGTesting\\Images\\MainIconSmall.bmp";
            cmdGroup.SmallMainIcon = "U:\\SWPLUGINS\\DGTesting\\Images\\MainIconSmall.bmp";
            cmdGroup.LargeIconList = "U:\\SWPLUGINS\\DGTesting\\Images\\ToolbarSmall.bmp";
            cmdGroup.SmallIconList = "U:\\SWPLUGINS\\DGTesting\\Images\\ToolbarSmall.bmp";
            
            cmdGroup.AddCommandItem("Draw Internal", -1, "", "Draw Internal", 1, "DrawInternal", "InternalEnabled", 1);

            cmdGroup.HasToolbar = true;
            cmdGroup.HasMenu = true;
            cmdGroup.Activate();

            return true;
        }

        public bool DisconnectFromSW() {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(iSwApp);
            iSwApp = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            return true;
        }

        public int InternalEnabled() {
            return 1;
        }

        public void DrawInternal() {
            ModelDoc2 doc = iSwApp.ActiveDoc;
            FeatureManager mgr = doc.FeatureManager;
            /*
            SelectionMgr mgr1 = doc.SelectionManager;
            int objectTypeInt;
            mgr1.GetSelectByIdSpecification(mgr1.GetSelectedObject5(0), out string _, out string _, out objectTypeInt);
            iSwApp.SendMsgToUser("" + objectTypeInt);
            */
            ISpurMF.PMPage page = new ISpurMF.PMPage(iSwApp);
            page.Show();
        }
        #endregion
    }
}
