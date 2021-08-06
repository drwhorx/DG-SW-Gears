using System;
using SolidWorks.Interop.swconst;
using System.Collections.Generic;

namespace CustomEnums {
    public enum ControlType {
        Label = swPropertyManagerPageControlType_e.swControlType_Label,
        Checkbox = swPropertyManagerPageControlType_e.swControlType_Checkbox,
        Button = swPropertyManagerPageControlType_e.swControlType_Button,
        Option = swPropertyManagerPageControlType_e.swControlType_Option,
        Textbox = swPropertyManagerPageControlType_e.swControlType_Textbox,
        Listbox = swPropertyManagerPageControlType_e.swControlType_Listbox,
        Combobox = swPropertyManagerPageControlType_e.swControlType_Combobox,
        Numberbox = swPropertyManagerPageControlType_e.swControlType_Numberbox,
        Selectionbox = swPropertyManagerPageControlType_e.swControlType_Selectionbox,
        ActiveX = swPropertyManagerPageControlType_e.swControlType_ActiveX,
        BitmapButton = swPropertyManagerPageControlType_e.swControlType_BitmapButton,
        CheckableBitmapButton = swPropertyManagerPageControlType_e.swControlType_CheckableBitmapButton,
        Slider = swPropertyManagerPageControlType_e.swControlType_Slider,
        Bitmap = swPropertyManagerPageControlType_e.swControlType_Bitmap,
        WindowFromHandle = swPropertyManagerPageControlType_e.swControlType_WindowFromHandle
    }
    
    public enum ControlAlign {
        Left = swPropertyManagerPageControlLeftAlign_e.swControlAlign_LeftEdge,
        Indent = swPropertyManagerPageControlLeftAlign_e.swControlAlign_Indent,
        DoubleIndent = swPropertyManagerPageControlLeftAlign_e.swControlAlign_DoubleIndent
    }

    public enum ControlOptions {
        Visible = swAddControlOptions_e.swControlOptions_Visible,
        Enabled = swAddControlOptions_e.swControlOptions_Enabled,
        Tight = swAddControlOptions_e.swControlOptions_SmallGapAbove
    }

    public enum PMButtons {
        OkayButton = swPropertyManagerButtonTypes_e.swPropertyManager_OkayButton,
        CancelButton = swPropertyManagerButtonTypes_e.swPropertyManager_CancelButton,
        HelpButton = swPropertyManagerButtonTypes_e.swPropertyManager_HelpButton,
        PreviewButton = swPropertyManagerButtonTypes_e.swPropertyManager_PreviewButton,
        PushpinButton = swPropertyManagerButtonTypes_e.swPropertyManager_PushpinButton
    }

    public enum PMGroupOptions {
        Checkbox = swAddGroupBoxOptions_e.swGroupBoxOptions_Checkbox,
        Checked = swAddGroupBoxOptions_e.swGroupBoxOptions_Checked,
        Visible = swAddGroupBoxOptions_e.swGroupBoxOptions_Visible,
        Expanded = swAddGroupBoxOptions_e.swGroupBoxOptions_Expanded
    }

    public enum BitmapButtons {
        alongz = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_alongz,
        angle = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_angle,
        auto_bal_circular = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_auto_bal_circular,
        auto_bal_left = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_auto_bal_left,
        auto_bal_right = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_auto_bal_right,
        auto_bal_square = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_auto_bal_square,
        auto_bal_top = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_auto_bal_top,
        diameter = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_diameter,
        distance1 = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_distance1,
        distance2 = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_distance2,
        draft = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_draft,
        cmark_bolt = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_dve_but_cmark_bolt,
        cmark_linear = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_dve_but_cmark_linear,
        cmark_single = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_dve_but_cmark_single,
        leader_ang_above = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_leader_ang_above,
        leader_ang_beside = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_leader_ang_beside,
        leader_hor_above = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_leader_hor_above,
        leader_hor_beside = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_leader_hor_beside,
        leader_left = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_leader_left,
        leader_no = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_leader_no,
        leader_right = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_leader_right,
        leader_yes = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_leader_yes,
        parallel = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_parallel,
        perpendicular = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_perpendicular,
        reverse_direction = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_reverse_direction,
        revision_circle = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_revision_circle,
        revision_hexagon = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_revision_hexagon,
        revision_square = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_revision_square,
        revision_triangle = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_revision_triangle,
        stackleft = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_stackleft,
        stackright = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_stackright,
        stackup = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_stackup,
        stack = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_stack,
        favorite_add = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_favorite_add,
        favorite_delete = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_favorite_delete,
        favorite_save = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_favorite_save,
        favorite_load = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_favorite_load,
        dim_set_default = swPropertyManagerPageBitmapButtons_e.swBitmapButtonImage_dimension_set_default_attributes
    }

    public enum BitmapLabels {
        LinearDistance = swControlBitmapLabelType_e.swBitmapLabel_LinearDistance,
        AngularDistance = swControlBitmapLabelType_e.swBitmapLabel_AngularDistance,
        SelectEdgeFaceVertex = swControlBitmapLabelType_e.swBitmapLabel_SelectEdgeFaceVertex,
        SelectFaceSurface = swControlBitmapLabelType_e.swBitmapLabel_SelectFaceSurface,
        SelectVertex = swControlBitmapLabelType_e.swBitmapLabel_SelectVertex,
        SelectFace = swControlBitmapLabelType_e.swBitmapLabel_SelectFace,
        SelectEdge = swControlBitmapLabelType_e.swBitmapLabel_SelectEdge,
        SelectFaceEdge = swControlBitmapLabelType_e.swBitmapLabel_SelectFaceEdge,
        SelectComponent = swControlBitmapLabelType_e.swBitmapLabel_SelectComponent,
        Diameter = swControlBitmapLabelType_e.swBitmapLabel_Diameter,
        Radius = swControlBitmapLabelType_e.swBitmapLabel_Radius,
        LinearDistance1 = swControlBitmapLabelType_e.swBitmapLabel_LinearDistance1,
        LinearDistance2 = swControlBitmapLabelType_e.swBitmapLabel_LinearDistance2,
        Thickness1 = swControlBitmapLabelType_e.swBitmapLabel_Thickness1,
        Thickness2 = swControlBitmapLabelType_e.swBitmapLabel_Thickness2,
        LinearPattern = swControlBitmapLabelType_e.swBitmapLabel_LinearPattern,
        CircularPattern = swControlBitmapLabelType_e.swBitmapLabel_CircularPattern,
        Width = swControlBitmapLabelType_e.swBitmapLabel_Width,
        Depth = swControlBitmapLabelType_e.swBitmapLabel_Depth,
        KFactor = swControlBitmapLabelType_e.swBitmapLabel_KFactor,
        BendAllowance = swControlBitmapLabelType_e.swBitmapLabel_BendAllowance,
        BendDeduction = swControlBitmapLabelType_e.swBitmapLabel_BendDeduction,
        RipGap = swControlBitmapLabelType_e.swBitmapLabel_RipGap,
        SelectProfile = swControlBitmapLabelType_e.swBitmapLabel_SelectProfile,
        SelectBoundary = swControlBitmapLabelType_e.swBitmapLabel_SelectBoundary
    }

    public enum NumBoxType {
        UnitlessInteger = swNumberboxUnitType_e.swNumberBox_UnitlessInteger,
        UnitlessDouble = swNumberboxUnitType_e.swNumberBox_UnitlessDouble,
        Length = swNumberboxUnitType_e.swNumberBox_Length,
        Angle = swNumberboxUnitType_e.swNumberBox_Angle,
        Density = swNumberboxUnitType_e.swNumberBox_Density,
        Stress = swNumberboxUnitType_e.swNumberBox_Stress,
        Force = swNumberboxUnitType_e.swNumberBox_Force,
        Gravity = swNumberboxUnitType_e.swNumberBox_Gravity,
        Time = swNumberboxUnitType_e.swNumberBox_Time,
        Frequency = swNumberboxUnitType_e.swNumberBox_Frequency,
        Percent = swNumberboxUnitType_e.swNumberBox_Percent
    }

    public enum PMCloseReason {
        UnknownReason = swPropertyManagerPageCloseReasons_e.swPropertyManagerPageClose_UnknownReason,
        Okay = swPropertyManagerPageCloseReasons_e.swPropertyManagerPageClose_Okay,
        Cancel = swPropertyManagerPageCloseReasons_e.swPropertyManagerPageClose_Cancel,
        ParentClosed = swPropertyManagerPageCloseReasons_e.swPropertyManagerPageClose_ParentClosed,
        Closed = swPropertyManagerPageCloseReasons_e.swPropertyManagerPageClose_Closed,
        UserEscape = swPropertyManagerPageCloseReasons_e.swPropertyManagerPageClose_UserEscape,
        Apply = swPropertyManagerPageCloseReasons_e.swPropertyManagerPageClose_Apply,
        Preview = swPropertyManagerPageCloseReasons_e.swPropertyManagerPageClose_Preview
    }

    public enum MacroFeatureDataType {
        String = swMacroFeatureParamType_e.swMacroFeatureParamTypeString,
        Double = swMacroFeatureParamType_e.swMacroFeatureParamTypeDouble,
        Integer = swMacroFeatureParamType_e.swMacroFeatureParamTypeInteger
    }
    public static class Icons {
        public static string[] Internal = { "U:\\SWPLUGINS\\DGTesting\\Images\\Internal.bmp" };
    }

    public static class Blocks {
        public static string Internal = "W:\\Logistics\\CAD Tools\\SolidWorks\\Blocks\\AMON\\PART BLOCKS\\INTERNAL INVOLUTE.SLDBLK";
    }
}