﻿Imports System.Threading.Tasks

Public Class HostContPresentationLayer

    Private Shared Message As New System.Text.StringBuilder

#Region "MESSAGE-METHODS"

    Public Shared Sub GamePlayStateSet(Optional MomentStatus As String = "")

        SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?QuestionText={Uri.EscapeDataString(Quiz_Operator.QuestionText)}&Answer1Text={Uri.EscapeDataString(Quiz_Operator.Answer1Text)}&Answer2Text={Uri.EscapeDataString(Quiz_Operator.Answer2Text)}&Answer3Text={Uri.EscapeDataString(Quiz_Operator.Answer3Text)}&Answer4Text={Uri.EscapeDataString(Quiz_Operator.Answer4Text)}&FinalAnswer={Quiz_Operator.FinalAnswer}&CorrectAnswer={Quiz_Operator.CorrectAnswer}&ExplanationText={Uri.EscapeDataString(Quiz_Operator.Explanation)}&PronunciationText={Uri.EscapeDataString(Quiz_Operator.Pronunciation)}&ContestantNameCity={String.Format("{0} {1}", Uri.EscapeDataString(Quiz_Operator.ContestantName_Textbox.Text), Uri.EscapeDataString(Quiz_Operator.ContestantLastName_Textbox.Text))}&PartnerName={String.Format("{0}", Uri.EscapeDataString(Quiz_Operator.ContestantPartner_Textbox.Text))}&BankDropIfCorrectIfWrong={Quiz_Operator.CurentGameStatusData}&QLevel={Math.Max(Quiz_Operator.LevelQ - 1, 0)}&LifelinesState={Quiz_Operator.LifelinesState}&FiftyFifty={Quiz_Operator.FiftyFifty}&AtaPercents={Quiz_Operator.AtaVotes}&SecondMilestoneAt={Quiz_Operator.VariableMilestone_TextBox.Text}&DoubleDipState={Quiz_Operator.DoubleDipState}&DoubleDipFirstAnswer={Quiz_Operator.DoubleDipFirstAnswer}&ActiveLifelines={Quiz_Operator.NumberOfActiveLifelines}")
        If MomentStatus.Trim = String.Empty Then Return
        Select Case MomentStatus.ToUpper
            Case "QUESTIONANSWERS_LOAD" 'QuestionAnswersState=

            Case "EMPTYQUESTION_FIRED"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?QuestionAnswersState=None&AtaState=None&Paf=None")
            Case "QUESTION_FIRED"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?QuestionAnswersState=ReadQ&AtaState=None&Paf=None")
            Case "QUESTION_ANSWERA_FIRED"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?QuestionAnswersState=ReadQ1&AtaState=None&Paf=None")
            Case "QUESTION_ANSWERB_FIRED"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?QuestionAnswersState=ReadQ12&AtaState=None&Paf=None")
            Case "QUESTION_ANSWERC_FIRED"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?QuestionAnswersState=ReadQ123&AtaState=None&Paf=None")
            Case "QUESTION_ANSWERD_FIRED"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?QuestionAnswersState=ReadQ1234&AtaState=None&Paf=None")
            Case "ANSWERA_FINAL_FIRED", "ANSWERB_FINAL_FIRED", "ANSWERC_FINAL_FIRED", "ANSWERD_FINAL_FIRED", "DOUBLEDIPANSWER_FINAL_FIRED"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?QuestionAnswersState=FinalAnswerGiven&FinalAnswer={Quiz_Operator.FinalAnswer}")
            Case "CORRECTANSWER_FIRED", "DOUBLEDIPISFIRSTFINALANSWER_CORRECT_FIRED"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?QuestionAnswersState=CorrectAnswerReveal")
            Case "EMPTYQUESTION_FIRED"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?QuestionAnswersState=None")
            'Case "LIFELINE_UPDATE"
            '    SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?LifelinesState={Quiz_Operator.LifelinesState}")
            Case "5050_FIRE"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?FiftyFifty={Quiz_Operator.FiftyFifty}")

            Case "PHONEFRIEND_DIALING"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?Paf=None")

            Case "PHONEFRIEND_PROGRESS"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?Paf=Start")

            Case "PHONEFRIEND_INTERRUPTED", "PHONEFRIEND_END"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?Paf=None")

            Case "ASKAUDIENCE_QUESTIONING"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?AtaState=NONE")

            Case "ASKAUDIENCE_VOTING"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?AtaState=ClearDiagram")

            Case "ASKAUDIENCE_ENDVOTE"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?AtaState=DiagramWithPercentage")

            Case "TOTALPRIZEWON"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostMainGamePlayState.php?QuestionAnswersState=TOTALPRIZEWON|{Quiz_Operator.QuestionForSume.ToString}")

        End Select
    End Sub

    Public Shared Sub ConfigurationMoneyTreeSet()
        SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/configuration-data/PostMoneyTreeConfigurationData.php?Q1={Quiz_Operator.QSum1_TextBox.Text}&Q2={Quiz_Operator.QSum2_TextBox.Text}&Q3={Quiz_Operator.QSum3_TextBox.Text}&Q4={Quiz_Operator.QSum4_TextBox.Text}&Q5={Quiz_Operator.QSum5_TextBox.Text}&Q6={Quiz_Operator.QSum6_TextBox.Text}&Q7={Quiz_Operator.QSum7_TextBox.Text}&Q8={Quiz_Operator.QSum8_TextBox.Text}&Q9={Quiz_Operator.QSum9_TextBox.Text}&Q10={Quiz_Operator.QSum10_TextBox.Text}&Q11={Quiz_Operator.QSum11_TextBox.Text}&Q12={Quiz_Operator.QSum12_TextBox.Text}&Q13={Quiz_Operator.QSum13_TextBox.Text}&Q14={Quiz_Operator.QSum14_TextBox.Text}&Q15={Quiz_Operator.QSum15_TextBox.Text}")
    End Sub

    Public Shared Sub ConfigurationLifelines(LF1 As String, LF2 As String, LF3 As String, LF4 As String, LF5 As String)
        SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/configuration-data/PostLifelineConfigurationData.php?Lifeline1={LF1}&Lifeline2={LF2}&Lifeline3={LF3}&Lifeline4={LF4}&Lifeline5={LF5}")
    End Sub

    Public Shared Sub ConfigurationLocalization(ANSWERMARKS As String, TPWONTAG As String)
        SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/configuration-data/PostLocalizationConfigurationData.php?AnswerMarks={ANSWERMARKS}&TpWon={TPWONTAG}")
    End Sub

    Public Shared Sub OneTimeMessageSet(Optional OneTimeMessage As String = "")

        If OneTimeMessage.Trim = String.Empty Then Return
        Select Case OneTimeMessage.ToUpper
            Case "EXPLANATION-FIRE"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostOneTimeMessage.php?MessageType=Explanation&State=Fired")
                'http://127.0.0.1/wwtbam-state/PostOneTimeMessage.php?MessageType=Explanation&State=Fired
            Case "EXPLANATION-NONE"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostOneTimeMessage.php?MessageType=Explanation&State=None")
                'http://127.0.0.1/wwtbam-state/PostOneTimeMessage.php?MessageType=Explanation&State=None
            Case "CONFIGURATION-RESET"
                SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostOneTimeMessage.php?MessageType=Other&State=ConfigurationReset")
        End Select

    End Sub

    Friend Shared Sub ExplanationFire()
        Return
        Message.Clear()
        Message.Append("<HOSTCONT-MESSAGE>")
        Message.Append("<MESSAGE-TYPE>EXPLANATIONFIRE</MESSAGE-TYPE>")
        Message.Append("</HOSTCONT-MESSAGE>")
    End Sub

    Friend Shared Sub ExplanationDissolve()
        Return
        Message.Clear()
        Message.Append("<HOSTCONT-MESSAGE>")
        Message.Append("<MESSAGE-TYPE>EXPLANATIONDISSOLVE</MESSAGE-TYPE>")
        Message.Append("</HOSTCONT-MESSAGE>")
    End Sub

    Friend Shared Sub GetDirectorChat(imessage As String, blink As String)
        Dim ChatState As String = "NONE"
        Dim intBlink As Integer
        If Not Integer.TryParse(blink, intBlink) Then
            intBlink = 0
        End If
        If intBlink > 0 Then
            ChatState = $"BLINK{intBlink.ToString}"
        End If
        SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostProducerChatState.php?ProducerChatState={ChatState}&ProducerChatText={Uri.EscapeDataString(imessage)}")

    End Sub

    Friend Shared Sub DirectorChatReset()
        SendHostContestantData($"https://{My.Settings.StateServerIPAddress}/wwtbam-state/PostProducerChatState.php?ProducerChatState=&ProducerChatText=")

    End Sub

    Public Shared Function SendHostContestantData(uri As String) As Boolean
        If Quiz_Operator.EnableHostContScreens_CheckBox.Checked = False Then
            Return False
        End If

        Dim returnDataFromRequest As String = HttpApiRequests.GetPostRequests.Get(uri)
        Task.Run(Sub()
                     Log.LogWrite(returnDataFromRequest)
                 End Sub)

        Return True
    End Function

#End Region
End Class
