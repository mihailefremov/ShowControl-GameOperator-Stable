Public Class GuiContext

    Private Shared _currentlyActiveLifelinePosition As Short
    Public Shared Property CurrentlyActiveLifelinePosition As Short
        Get
            Return _currentlyActiveLifelinePosition
        End Get
        Set(value As Short)
            _currentlyActiveLifelinePosition = value
        End Set
    End Property

    Public Shared ReadOnly Property GuiLifelines As String()
        Get
            Dim lfl(5) As String
            lfl = (Quiz_Operator.ActiveLifelinesNames + ";;;;").Split(";")
            Return lfl
        End Get
    End Property

    Private Shared lifeline1Active1 As Short = 1
    Public Shared Property Lifeline1Active As Short
        Get
            Return lifeline1Active1
        End Get
        Set(value As Short)
            lifeline1Active1 = value
            GraphicsProcessingUnit.MarkCGlifelines(lifeline1Active1, Lifeline2Active, Lifeline3Active, Lifeline4Active)
            HostContPresentationLayer.GamePlayStateSet("LIFELINE_UPDATE")
        End Set
    End Property

    Private Shared lifeline2Active1 As Short = 1
    Public Shared Property Lifeline2Active As Short
        Get
            Return lifeline2Active1
        End Get
        Set(value As Short)
            lifeline2Active1 = value
            GraphicsProcessingUnit.MarkCGlifelines(lifeline1Active1, Lifeline2Active, Lifeline3Active, Lifeline4Active)
            HostContPresentationLayer.GamePlayStateSet("LIFELINE_UPDATE")
        End Set
    End Property

    Private Shared lifeline3Active1 As Short = 1
    Public Shared Property Lifeline3Active As Short
        Get
            Return lifeline3Active1
        End Get
        Set(value As Short)
            lifeline3Active1 = value
            GraphicsProcessingUnit.MarkCGlifelines(lifeline1Active1, Lifeline2Active, Lifeline3Active, Lifeline4Active)
            HostContPresentationLayer.GamePlayStateSet("LIFELINE_UPDATE")
        End Set
    End Property

    Private Shared lifeline4Active1 As Short = 1
    Public Shared Property Lifeline4Active As Short
        Get
            Return lifeline4Active1
        End Get
        Set(value As Short)
            lifeline4Active1 = value
            GraphicsProcessingUnit.MarkCGlifelines(lifeline1Active1, Lifeline2Active, Lifeline3Active, Lifeline4Active)
            HostContPresentationLayer.GamePlayStateSet("LIFELINE_UPDATE")
        End Set
    End Property

    Public Enum LifelineAction
        Used = 0
        NotUsed = 1
        InUse = 2
    End Enum

    Friend Shared Sub SomethingToDoWithLifeline(lifelinePosition As Short, action As LifelineAction)
        Select Case lifelinePosition
            Case 1
                Lifeline1Active = action
            Case 2
                Lifeline2Active = action
            Case 3
                Lifeline3Active = action
            Case 4
                Lifeline4Active = action
        End Select
        Select Case action
            Case LifelineAction.Used
                XmarkLifeline(lifelinePosition)
            Case LifelineAction.NotUsed
                UnusedLifeline(lifelinePosition)
            Case LifelineAction.InUse
                InUsemarkLifeline(lifelinePosition)
        End Select
    End Sub

    Friend Shared Sub ResetAll()
        UnusedLifeline(1)
        UnusedLifeline(2)
        UnusedLifeline(3)
        UnusedLifeline(4)
    End Sub

    Friend Shared Sub UnusedLifeline(lifelinePosition As Integer)
        If lifelinePosition = 1 Then
            Quiz_Operator.Lifeline1_PictureBox.BackgroundImage = My.Resources.ResourceManager.GetObject($"{GuiLifelines.ElementAt(0).ToUpper}_0")
        ElseIf lifelinePosition = 2 Then
            Quiz_Operator.Lifeline2_PictureBox.BackgroundImage = My.Resources.ResourceManager.GetObject($"{GuiLifelines.ElementAt(1).ToUpper}_0")
        ElseIf lifelinePosition = 3 Then
            Quiz_Operator.Lifeline3_PictureBox.BackgroundImage = My.Resources.ResourceManager.GetObject($"{GuiLifelines.ElementAt(2).ToUpper}_0")
        ElseIf lifelinePosition = 4 Then
            Quiz_Operator.Lifeline4_PictureBox.BackgroundImage = My.Resources.ResourceManager.GetObject($"{GuiLifelines.ElementAt(3).ToUpper}_0")
        End If
    End Sub


    Friend Shared Sub InUsemarkLifeline(lifelinePosition As Integer)
        If lifelinePosition = 1 Then
            Quiz_Operator.Lifeline1_PictureBox.BackgroundImage = My.Resources.ResourceManager.GetObject($"{GuiLifelines.ElementAt(0).ToUpper}_1")
        ElseIf lifelinePosition = 2 Then
            Quiz_Operator.Lifeline2_PictureBox.BackgroundImage = My.Resources.ResourceManager.GetObject($"{GuiLifelines.ElementAt(1).ToUpper}_1")
        ElseIf lifelinePosition = 3 Then
            Quiz_Operator.Lifeline3_PictureBox.BackgroundImage = My.Resources.ResourceManager.GetObject($"{GuiLifelines.ElementAt(2).ToUpper}_1")
        ElseIf lifelinePosition = 4 Then
            Quiz_Operator.Lifeline4_PictureBox.BackgroundImage = My.Resources.ResourceManager.GetObject($"{GuiLifelines.ElementAt(3).ToUpper}_1")
        End If
    End Sub

    Friend Shared Sub XmarkLifeline(lifelinePosition As Integer)
        If lifelinePosition = 1 Then
            Quiz_Operator.Lifeline1_PictureBox.BackgroundImage = My.Resources.ResourceManager.GetObject($"{GuiLifelines.ElementAt(0).ToUpper}_X")
        ElseIf lifelinePosition = 2 Then
            Quiz_Operator.Lifeline2_PictureBox.BackgroundImage = My.Resources.ResourceManager.GetObject($"{GuiLifelines.ElementAt(1).ToUpper}_X")
        ElseIf lifelinePosition = 3 Then
            Quiz_Operator.Lifeline3_PictureBox.BackgroundImage = My.Resources.ResourceManager.GetObject($"{GuiLifelines.ElementAt(2).ToUpper}_X")
        ElseIf lifelinePosition = 4 Then
            Quiz_Operator.Lifeline4_PictureBox.BackgroundImage = My.Resources.ResourceManager.GetObject($"{GuiLifelines.ElementAt(3).ToUpper}_X")
        End If
    End Sub

    Friend Shared Sub PositionLifelineTab(position As Short)

        EnableTabs({Quiz_Operator.FiftyFiftyLifeline_TabPage, Quiz_Operator.PhoneAfriendLifeline_TabPage, Quiz_Operator.AskTheAudienceLifeline_TabPage,
                   Quiz_Operator.SwitchTheQuestionLifeline_TabPage, Quiz_Operator.DoubleDipLifeline_TabPage}, False)

        If (position < 1) Or (position > 5) Then Return
        Dim Lifeline As String = GuiLifelines.ElementAt(position - 1)

        Select Case Lifeline.ToUpper
            Case "5050"
                Quiz_Operator.TabControl2.SelectedTab = Quiz_Operator.TabPage7
                Quiz_Operator.TabControl1.SelectedTab = Quiz_Operator.FiftyFiftyLifeline_TabPage
                EnableTab(Quiz_Operator.FiftyFiftyLifeline_TabPage, True)
            Case "PAF"
                Quiz_Operator.TabControl2.SelectedTab = Quiz_Operator.TabPage7
                Quiz_Operator.TabControl1.SelectedTab = Quiz_Operator.PhoneAfriendLifeline_TabPage
                EnableTab(Quiz_Operator.PhoneAfriendLifeline_TabPage, True)
            Case "ATA"
                Quiz_Operator.TabControl2.SelectedTab = Quiz_Operator.TabPage7
                Quiz_Operator.TabControl1.SelectedTab = Quiz_Operator.AskTheAudienceLifeline_TabPage
                EnableTab(Quiz_Operator.AskTheAudienceLifeline_TabPage, True)
            Case "STQ"
                Quiz_Operator.TabControl2.SelectedTab = Quiz_Operator.TabPage7
                Quiz_Operator.TabControl1.SelectedTab = Quiz_Operator.SwitchTheQuestionLifeline_TabPage
                EnableTab(Quiz_Operator.SwitchTheQuestionLifeline_TabPage, True)
            Case "DDIP"
                Quiz_Operator.TabControl2.SelectedTab = Quiz_Operator.TabPage7
                Quiz_Operator.TabControl1.SelectedTab = Quiz_Operator.DoubleDipLifeline_TabPage
                EnableTab(Quiz_Operator.DoubleDipLifeline_TabPage, True)
            Case "ATH"

            Case "ATE"

        End Select

    End Sub

    Friend Shared Sub FiftyFiftyResetOptionOperator(CorrectAnswer As String)
        Quiz_Operator.AremoveFF_Label.Visible = True
        Quiz_Operator.BremoveFF_Label.Visible = True
        Quiz_Operator.CremoveFF_Label.Visible = True
        Quiz_Operator.DremoveFF_Label.Visible = True

        Select Case CorrectAnswer
            Case 1
                Quiz_Operator.AremoveFF_Label.Visible = False
            Case 2
                Quiz_Operator.BremoveFF_Label.Visible = False
            Case 3
                Quiz_Operator.CremoveFF_Label.Visible = False
            Case 4
                Quiz_Operator.DremoveFF_Label.Visible = False
        End Select
    End Sub

    Public Shared Sub EnableTab(ByVal page As TabPage, ByVal enable As Boolean)
        For Each ctl As Control In page.Controls
            ctl.Enabled = enable
        Next
    End Sub

    Public Shared Sub EnableTabs(ByVal page() As TabPage, ByVal enable As Boolean)
        For Each p As TabPage In page
            For Each ctl As Control In p.Controls
                ctl.Enabled = enable
            Next
        Next
    End Sub

    Public Shared CommonGraphicsConfiguration As Xml2CSharp.GRAPHICSGAMECONFIGURATION

End Class
