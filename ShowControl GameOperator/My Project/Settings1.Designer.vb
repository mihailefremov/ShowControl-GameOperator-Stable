﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.9.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property username() As String
            Get
                Return CType(Me("username"),String)
            End Get
            Set
                Me("username") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property password() As String
            Get
                Return CType(Me("password"),String)
            End Get
            Set
                Me("password") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property ContestantNameSurname() As String
            Get
                Return CType(Me("ContestantNameSurname"),String)
            End Get
            Set
                Me("ContestantNameSurname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Biography() As String
            Get
                Return CType(Me("Biography"),String)
            End Get
            Set
                Me("Biography") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("WWTBAM-4K-QA/WWTBAM-4K-QA")>  _
        Public Property questionFlashTempl() As String
            Get
                Return CType(Me("questionFlashTempl"),String)
            End Get
            Set
                Me("questionFlashTempl") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("192.168.100.2")>  _
        Public Property casparHostName() As String
            Get
                Return CType(Me("casparHostName"),String)
            End Get
            Set
                Me("casparHostName") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("5250")>  _
        Public Property casparPort() As Integer
            Get
                Return CType(Me("casparPort"),Integer)
            End Get
            Set
                Me("casparPort") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("//")>  _
        Public Property contestantHomeTown() As String
            Get
                Return CType(Me("contestantHomeTown"),String)
            End Get
            Set
                Me("contestantHomeTown") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("//")>  _
        Public Property contestantGuest() As String
            Get
                Return CType(Me("contestantGuest"),String)
            End Get
            Set
                Me("contestantGuest") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("127.0.0.1")>  _
        Public Property audienceVotesServer() As String
            Get
                Return CType(Me("audienceVotesServer"),String)
            End Get
            Set
                Me("audienceVotesServer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("root")>  _
        Public Property mySqlUser() As String
            Get
                Return CType(Me("mySqlUser"),String)
            End Get
            Set
                Me("mySqlUser") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("P@ssw0rd")>  _
        Public Property mySqlPassword() As String
            Get
                Return CType(Me("mySqlPassword"),String)
            End Get
            Set
                Me("mySqlPassword") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("wwtbam")>  _
        Public Property audienceVotesDatabase() As String
            Get
                Return CType(Me("audienceVotesDatabase"),String)
            End Get
            Set
                Me("audienceVotesDatabase") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("audiencevotes")>  _
        Public Property audienceVotesTable() As String
            Get
                Return CType(Me("audienceVotesTable"),String)
            End Get
            Set
                Me("audienceVotesTable") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("WWTBAM-4K-MT/WWTBAM-4K-MT")>  _
        Public Property moneyTreeFlashTempl() As String
            Get
                Return CType(Me("moneyTreeFlashTempl"),String)
            End Get
            Set
                Me("moneyTreeFlashTempl") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("wwtbam/currentWorking/FFFRightOrderUIp2")>  _
        Public Property rightOrderFlashTempl() As String
            Get
                Return CType(Me("rightOrderFlashTempl"),String)
            End Get
            Set
                Me("rightOrderFlashTempl") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("wwtbam/currentWorking/FFFWhoIsRightUIp1v1LowPerformance")>  _
        Public Property whoIsCorrectFlashTempl() As String
            Get
                Return CType(Me("whoIsCorrectFlashTempl"),String)
            End Get
            Set
                Me("whoIsCorrectFlashTempl") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("127.0.0.1")>  _
        Public Property QuizOperatorIPAddress() As String
            Get
                Return CType(Me("QuizOperatorIPAddress"),String)
            End Get
            Set
                Me("QuizOperatorIPAddress") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property DebugMode() As Boolean
            Get
                Return CType(Me("DebugMode"),Boolean)
            End Get
            Set
                Me("DebugMode") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("wwtbam/currentWorking/FFFNameStrapFastestUIp1v2")>  _
        Public Property fastestNameClokStrapFlashTempl() As String
            Get
                Return CType(Me("fastestNameClokStrapFlashTempl"),String)
            End Get
            Set
                Me("fastestNameClokStrapFlashTempl") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("3")>  _
        Public Property FFFClockDecimalPlaces() As Integer
            Get
                Return CType(Me("FFFClockDecimalPlaces"),Integer)
            End Get
            Set
                Me("FFFClockDecimalPlaces") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("127.0.0.1")>  _
        Public Property StateServerIPAddress() As String
            Get
                Return CType(Me("StateServerIPAddress"),String)
            End Get
            Set
                Me("StateServerIPAddress") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property IsInteractiveScreenOn() As Boolean
            Get
                Return CType(Me("IsInteractiveScreenOn"),Boolean)
            End Get
            Set
                Me("IsInteractiveScreenOn") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("DESKTOP-4MKSC1R")>  _
        Public Property gameQuestionsServer() As String
            Get
                Return CType(Me("gameQuestionsServer"),String)
            End Get
            Set
                Me("gameQuestionsServer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property UseMySqlForAta() As Boolean
            Get
                Return CType(Me("UseMySqlForAta"),Boolean)
            End Get
            Set
                Me("UseMySqlForAta") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("WWTBAM-4K-PAF/WWTBAM-4K-PAF")>  _
        Public Property phoneAfriendFlashTempl() As String
            Get
                Return CType(Me("phoneAfriendFlashTempl"),String)
            End Get
            Set
                Me("phoneAfriendFlashTempl") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.ShowControl_GameOperator.My.MySettings
            Get
                Return Global.ShowControl_GameOperator.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
