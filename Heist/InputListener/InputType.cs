﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InputListener
{
    public enum InputType
    {
        A_Up,
        Add_Up,
        Apps_Up,
        Attn_Up,
        B_Up,
        Back_Up,
        BrowserBack_Up,
        BrowserFavorites_Up,
        BrowserForward_Up,
        BrowserHome_Up,
        BrowserRefresh_Up,
        BrowserSearch_Up,
        BrowserStop_Up,
        C_Up,
        CapsLock_Up,
        ChatPadGreen_Up,
        ChatPadOrange_Up,
        Crsel_Up,
        D_Up,
        D0_Up,
        D1_Up,
        D2_Up,
        D3_Up,
        D4_Up,
        D5_Up,
        D6_Up,
        D7_Up,
        D8_Up,
        D9_Up,
        Decimal_Up,
        Delete_Up,
        Divide_Up,
        Down_Up,
        E_Up,
        End_Up,
        Enter_Up,
        EraseEof_Up,
        Escape_Up,
        Execute_Up,
        Exsel_Up,
        F_Up,
        F1_Up,
        F10_Up,
        F11_Up,
        F12_Up,
        F13_Up,
        F14_Up,
        F15_Up,
        F16_Up,
        F17_Up,
        F18_Up,
        F19_Up,
        F2_Up,
        F20_Up,
        F21_Up,
        F22_Up,
        F23_Up,
        F24_Up,
        F3_Up,
        F4_Up,
        F5_Up,
        F6_Up,
        F7_Up,
        F8_Up,
        F9_Up,
        G_Up,
        H_Up,
        Help_Up,
        Home_Up,
        I_Up,
        ImeConvert_Up,
        ImeNoConvert_Up,
        Insert_Up,
        J_Up,
        K_Up,
        Kana_Up,
        Kanji_Up,
        L_Up,
        LaunchApplication1_Up,
        LaunchApplication2_Up,
        LaunchMail_Up,
        Left_Up,
        LeftAlt_Up,
        LeftControl_Up,
        LeftShift_Up,
        LeftWindows_Up,
        M_Up,
        MediaNextTrack_Up,
        MediaPlayPause_Up,
        MediaPreviousTrack_Up,
        MediaStop_Up,
        Multiply_Up,
        N_Up,
        None_Up,
        NumLock_Up,
        NumPad0_Up,
        NumPad1_Up,
        NumPad2_Up,
        NumPad3_Up,
        NumPad4_Up,
        NumPad5_Up,
        NumPad6_Up,
        NumPad7_Up,
        NumPad8_Up,
        NumPad9_Up,
        O_Up,
        Oem8_Up,
        OemAuto_Up,
        OemBackslash_Up,
        OemClear_Up,
        OemCloseBrackets_Up,
        OemComma_Up,
        OemCopy_Up,
        OemEnlW_Up,
        OemMinus_Up,
        OemOpenBrackets_Up,
        OemPeriod_Up,
        OemPipe_Up,
        OemPlus_Up,
        OemQuestion_Up,
        OemQuotes_Up,
        OemSemicolon_Up,
        OemTilde_Up,
        P_Up,
        Pa1_Up,
        PageDown_Up,
        PageUp_Up,
        Pause_Up,
        Play_Up,
        Print_Up,
        PrintScreen_Up,
        ProcessKey_Up,
        Q_Up,
        R_Up,
        Right_Up,
        RightAlt_Up,
        RightControl_Up,
        RightShift_Up,
        RightWindows_Up,
        S_Up,
        Scroll_Up,
        Select_Up,
        SelectMedia_Up,
        Separator_Up,
        Sleep_Up,
        Space_Up,
        Subtract_Up,
        T_Up,
        Tab_Up,
        U_Up,
        Up_Up,
        V_Up,
        VolumeDown_Up,
        VolumeMute_Up,
        VolumeUp_Up,
        W_Up,
        X_Up,
        Y_Up,
        Z_Up,
        Zoom_Up,
        A_Down,
        Add_Down,
        Apps_Down,
        Attn_Down,
        B_Down,
        Back_Down,
        BrowserBack_Down,
        BrowserFavorites_Down,
        BrowserForward_Down,
        BrowserHome_Down,
        BrowserRefresh_Down,
        BrowserSearch_Down,
        BrowserStop_Down,
        C_Down,
        CapsLock_Down,
        ChatPadGreen_Down,
        ChatPadOrange_Down,
        Crsel_Down,
        D_Down,
        D0_Down,
        D1_Down,
        D2_Down,
        D3_Down,
        D4_Down,
        D5_Down,
        D6_Down,
        D7_Down,
        D8_Down,
        D9_Down,
        Decimal_Down,
        Delete_Down,
        Divide_Down,
        Down_Down,
        E_Down,
        End_Down,
        Enter_Down,
        EraseEof_Down,
        Escape_Down,
        Execute_Down,
        Exsel_Down,
        F_Down,
        F1_Down,
        F10_Down,
        F11_Down,
        F12_Down,
        F13_Down,
        F14_Down,
        F15_Down,
        F16_Down,
        F17_Down,
        F18_Down,
        F19_Down,
        F2_Down,
        F20_Down,
        F21_Down,
        F22_Down,
        F23_Down,
        F24_Down,
        F3_Down,
        F4_Down,
        F5_Down,
        F6_Down,
        F7_Down,
        F8_Down,
        F9_Down,
        G_Down,
        H_Down,
        Help_Down,
        Home_Down,
        I_Down,
        ImeConvert_Down,
        ImeNoConvert_Down,
        Insert_Down,
        J_Down,
        K_Down,
        Kana_Down,
        Kanji_Down,
        L_Down,
        LaunchApplication1_Down,
        LaunchApplication2_Down,
        LaunchMail_Down,
        Left_Down,
        LeftAlt_Down,
        LeftControl_Down,
        LeftShift_Down,
        LeftWindows_Down,
        M_Down,
        MediaNextTrack_Down,
        MediaPlayPause_Down,
        MediaPreviousTrack_Down,
        MediaStop_Down,
        Multiply_Down,
        N_Down,
        None_Down,
        NumLock_Down,
        NumPad0_Down,
        NumPad1_Down,
        NumPad2_Down,
        NumPad3_Down,
        NumPad4_Down,
        NumPad5_Down,
        NumPad6_Down,
        NumPad7_Down,
        NumPad8_Down,
        NumPad9_Down,
        O_Down,
        Oem8_Down,
        OemAuto_Down,
        OemBackslash_Down,
        OemClear_Down,
        OemCloseBrackets_Down,
        OemComma_Down,
        OemCopy_Down,
        OemEnlW_Down,
        OemMinus_Down,
        OemOpenBrackets_Down,
        OemPeriod_Down,
        OemPipe_Down,
        OemPlus_Down,
        OemQuestion_Down,
        OemQuotes_Down,
        OemSemicolon_Down,
        OemTilde_Down,
        P_Down,
        Pa1_Down,
        PageDown_Down,
        PageUp_Down,
        Pause_Down,
        Play_Down,
        Print_Down,
        PrintScreen_Down,
        ProcessKey_Down,
        Q_Down,
        R_Down,
        Right_Down,
        RightAlt_Down,
        RightControl_Down,
        RightShift_Down,
        RightWindows_Down,
        S_Down,
        Scroll_Down,
        Select_Down,
        SelectMedia_Down,
        Separator_Down,
        Sleep_Down,
        Space_Down,
        Subtract_Down,
        T_Down,
        Tab_Down,
        U_Down,
        Up_Down,
        V_Down,
        VolumeDown_Down,
        VolumeMute_Down,
        VolumeUp_Down,
        W_Down,
        X_Down,
        Y_Down,
        Z_Down,
        Zoom_Down,
        MouseLeft_Up,
        MouseMiddle_Up,
        MouseRight_Up,
        MouseScroll_Up,
        MouseLeft_Down,
        MouseMiddle_Down,
        MouseRight_Down,
        MouseScroll_Down
    }

}
