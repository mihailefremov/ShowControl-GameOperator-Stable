﻿Imports System.Reflection.Emit
Imports System.Xml
Imports Newtonsoft.Json
Imports Svt.Caspar

Public Class GraphicsProcessingUnit

    Public Shared casparQA As New CasparDevice
    Public Shared casparMT As New CasparDevice
    Public Shared casparPhoneAFriend As New CasparDevice

    Public Shared cgDataQA As New CasparCGDataCollection
    Public Shared cgDataMT As New CasparCGDataCollection
    Public Shared cgDataPhoneAFriend As New CasparCGDataCollection

    Public Shared flagQforGraph As Boolean = False
    Public Shared flagATAgraph As Boolean = False
    Public Shared flagLifeLineRemindGraph As Boolean = False

    Public Shared numberoflifelines = 4

    Public Shared questionCGchannel As Int16 = 0
    Public Shared moneyTreeCGchannel As Int16 = 0
    Public Shared rightOrderCGhannel As Int16 = 0
    Public Shared whoAnsweredCorrectlyCGhannel As Int16 = 0
    Public Shared fastestNameStrapCGhannel As Int16 = 0
    Public Shared phoneAfriendCGchannel As Int16 = 0
    Public Shared wallScreenCGchannel As Int16 = 0

    Public Shared questionCGlayer As Int16 = 1
    Public Shared phoneAfriendCGlayer As Int16 = 2
    Public Shared moneyTreeCGlayer As Int16 = 3
    Public Shared rightOrderCGLayer As Int16 = 4
    Public Shared whoAnsweredCorrectlyCGLayer As Int16 = 5
    Public Shared fastestNameStrapCGLayer As Int16 = 5
    Public Shared wallScreenCGLayer As Int16 = 0

    Public Shared InteractiveWallScreenObj As New InteractiveWallScreen

    Public Shared Sub CGQuestionSet(Question As String, Answer1 As String, Answer2 As String, Answer3 As String, Answer4 As String, QuestionForSume As String, LifelinesNames As String)
        '' ******* CASPARCG ******* CASPARCG ******* CASPARCG ******* ******* CASPARCG ******* CASPARCG ******* CASPARCG *******
        '' CG 1-20 UPDATE 1 "{\"QuestionML_TextField\":\"АСДАСДКАПКДПАКСПДКАПКДПОАКПДАО\"}"\r\n

        Dim Question_Text As String
        Question_Text = Question

        cgDataQA.SetData("QuestionSL_TextField", "")
        cgDataQA.SetData("QuestionML_TextField", "")

        If Question_Text.Contains("|") Then
            cgDataQA.SetData("QuestionML_TextField", Question)
        Else
            cgDataQA.SetData("QuestionSL_TextField", Question)
        End If

        cgDataQA.SetData("AnswerA_TextField", Answer1)
        cgDataQA.SetData("AnswerB_TextField", Answer2)
        cgDataQA.SetData("AnswerC_TextField", Answer3)
        cgDataQA.SetData("AnswerD_TextField", Answer4)

        Dim AnswerMarks As Char() = Quiz_Operator.AnswerMarks.ToCharArray()

        cgDataQA.SetData("MarkA_TextField", IIf(AnswerMarks(0) = Nothing, "A", AnswerMarks(0)) + ":")
        cgDataQA.SetData("MarkB_TextField", IIf(AnswerMarks(1) = Nothing, "B", AnswerMarks(1)) + ":")
        cgDataQA.SetData("MarkC_TextField", IIf(AnswerMarks(2) = Nothing, "C", AnswerMarks(2)) + ":")
        cgDataQA.SetData("MarkD_TextField", IIf(AnswerMarks(3) = Nothing, "D", AnswerMarks(3)) + ":")

        cgDataQA.SetData("QuestionFor_TextField", QuestionForSume)

        cgDataQA.SetData("Lifelines_TextField", LifelinesNames)
        cgDataQA.SetData("UsedLifelines_TextField", Quiz_Operator.LifelinesState)

        cgDataQA.ToAMCPEscapedXml()

    End Sub

    Public Shared Sub showClockBarCG(LevelQ_TextBox As String)

        If LevelQ_TextBox <= 5 Then
            '' ******* CASPARCG ******* CASPARCG *******
            If casparQA.IsConnected Then
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "show15sClock")
            End If
            '' ******* CASPARCG ******* CASPARCG *******

        End If

        If LevelQ_TextBox > 5 Then
            '' ******* CASPARCG ******* CASPARCG *******
            If casparQA.IsConnected Then
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "show30sClock")
            End If
            '' ******* CASPARCG ******* CASPARCG *******

        End If

    End Sub

    Public Shared Sub hideClockBarCG(LevelQ_TextBox As String, IsGameLimited As Boolean)

        If LevelQ_TextBox <= 5 And IsGameLimited = True Then
            '' ******* CASPARCG ******* CASPARCG *******
            If casparQA.IsConnected Then
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "hide15sClock")
            End If
            '' ******* CASPARCG ******* CASPARCG *******

        End If
        If LevelQ_TextBox > 5 And IsGameLimited = True Then
            '' ******* CASPARCG ******* CASPARCG *******
            If casparQA.IsConnected Then
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "hide30sClock")
            End If
            '' ******* CASPARCG ******* CASPARCG *******

        End If

    End Sub

    Public Shared Sub CGtemplateSet()
        '' ******* CASPARCG ******* 
        If casparQA.IsConnected Then
            casparQA.Channels(questionCGchannel).CG.Add(questionCGlayer, questionCGchannel, My.Settings.questionFlashTempl, False, cgDataQA)
        End If
        '' ******* CASPARCG ******* 
    End Sub

    Friend Shared Sub WonPrizeReveal(LevelQ_TextBox As String, DescriptorPrizeWon As String, QuestionForSume As String)
        If LevelQ_TextBox = "111" Or LevelQ_TextBox = "666" Or LevelQ_TextBox = "16" Then
            '' ******* CASPARCG ******* CASPARCG *******
            cgDataQA.SetData("DescrPrizeWon_TextField", DescriptorPrizeWon)
            cgDataQA.SetData("TotalPrizeWon_TextField", QuestionForSume)

            '' ******* CASPARCG ******* CASPARCG *******
            If casparQA.IsConnected Then
                casparQA.Channels(questionCGchannel).CG.Update(questionCGlayer, questionCGchannel, cgDataQA)
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "TotalWinStrap_Show")
            End If
            '' ******* CASPARCG ******* CASPARCG *******
        ElseIf LevelQ_TextBox <> "888" Then

            '' ******* CASPARCG ******* CASPARCG *******
            cgDataQA.SetData("SumeWon_TextField", QuestionForSume)
            If casparQA.IsConnected Then
                casparQA.Channels(questionCGchannel).CG.Update(questionCGlayer, questionCGchannel, cgDataQA)
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "WinningStrap_Show")
            End If
            '' ******* CASPARCG ******* CASPARCG *******

        End If
    End Sub

    Friend Shared Sub FiftyFiftyTake(listRemoved As List(Of Short))
        If listRemoved.Contains(1) Then
            cgDataQA.SetData("AnswerA_TextField", "")
            cgDataQA.SetData("MarkA_TextField", "")
        End If
        If listRemoved.Contains(2) Then
            cgDataQA.SetData("AnswerB_TextField", "")
            cgDataQA.SetData("MarkB_TextField", "")
        End If
        If listRemoved.Contains(3) Then
            cgDataQA.SetData("AnswerC_TextField", "")
            cgDataQA.SetData("MarkC_TextField", "")
        End If
        If listRemoved.Contains(4) Then
            cgDataQA.SetData("AnswerD_TextField", "")
            cgDataQA.SetData("MarkD_TextField", "")
        End If
    End Sub

    Friend Shared Sub UpdateQAData()
        If casparQA.IsConnected Then
            casparQA.Channels(questionCGchannel).CG.Update(questionCGlayer, questionCGchannel, cgDataQA)
        End If
    End Sub

    Friend Shared Sub SetATAdata(aPub As String, bPub As String, cPub As String, dPub As String)
        cgDataQA.SetData("Apercent_TextField", aPub)
        cgDataQA.SetData("Bpercent_TextField", bPub)
        cgDataQA.SetData("Cpercent_TextField", cPub)
        cgDataQA.SetData("Dpercent_TextField", dPub)
        UpdateQAData()
    End Sub

    Friend Shared Sub Activate3Lifelines()
        numberoflifelines = 3
        If casparQA.IsConnected Then
            casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "threeLifelines")
        End If
        If casparMT.IsConnected Then
            casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, moneyTreeCGchannel, "threeLifelines")
        End If

    End Sub

    Public Shared Function LifelineRemind() As Boolean
        ActivateLifelines()
        If casparQA.IsConnected Then
            If flagLifeLineRemindGraph = False Then
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "lifelineRemindFlyIn")
                flagLifeLineRemindGraph = True

                'showLLRforGraph
            Else
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "lifelineRemindFlyOut")
                flagLifeLineRemindGraph = False
                'hideLLRforGraph
            End If
        End If
        Return flagLifeLineRemindGraph
    End Function

    Public Shared Sub MarkCGlifelines(lifeline1Active As Short, lifeline2Active As Short, lifeline3Active As Short, lifeline4Active As Short)
        If casparQA.IsConnected Then
            If lifeline1Active = 0 Then
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "markXLifeline1")
                casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, moneyTreeCGchannel, "markXLifeline1")
                'markXLifeline1
            End If
            If lifeline2Active = 0 Then
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "markXLifeline2")
                casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, moneyTreeCGchannel, "markXLifeline2")
                'markXLifeline2
            End If
            If lifeline3Active = 0 Then
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "markXLifeline3")
                casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, moneyTreeCGchannel, "markXLifeline3")
                'markXLifeline3
            End If
            If lifeline4Active = 0 Then
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "markXLifeline4")
                casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, moneyTreeCGchannel, "markXLifeline4")
                'markXLifeline4
            End If
            '''''''''''''''''
            If lifeline1Active = 1 Then
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "mark0Lifeline1")
                casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, moneyTreeCGchannel, "mark0Lifeline1")
                'markXLifeline1
            End If
            If lifeline2Active = 1 Then
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "mark0Lifeline2")
                casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, moneyTreeCGchannel, "mark0Lifeline2")
                'markXLifeline2
            End If
            If lifeline3Active = 1 Then
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "mark0Lifeline3")
                casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, moneyTreeCGchannel, "mark0Lifeline3")
                'markXLifeline3
            End If
            If lifeline4Active = 1 Then
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "mark0Lifeline4")
                casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, moneyTreeCGchannel, "mark0Lifeline4")
                'markXLifeline4
            End If
            Dim lif = String.Format("{0};{1};{2};{3}", Helpers.ConvertLifelineStateToReadable(lifeline1Active), Helpers.ConvertLifelineStateToReadable(lifeline2Active), Helpers.ConvertLifelineStateToReadable(lifeline3Active), Helpers.ConvertLifelineStateToReadable(lifeline4Active))
            cgDataMT.SetData("UsedLifelines_TextField", lif)
            casparMT.Channels(moneyTreeCGchannel).CG.Update(moneyTreeCGlayer, moneyTreeCGchannel, cgDataMT)

            cgDataQA.SetData("UsedLifelines_TextField", lif)
            casparQA.Channels(questionCGchannel).CG.Update(questionCGlayer, questionCGchannel, cgDataQA)

        End If
    End Sub

    Friend Shared Sub ActivateLifelines()
        Dim translatedLifelines As String = "three"
        If numberoflifelines = 3 Then
            translatedLifelines = "three"
        ElseIf numberoflifelines = 4 Then
            translatedLifelines = "four"
        End If

        If casparQA.IsConnected Then
            casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, $"{translatedLifelines}Lifelines")
        End If
        If casparMT.IsConnected Then
            casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, questionCGchannel, $"{translatedLifelines}Lifelines")
        End If
    End Sub

    Public Shared Sub setSecondMilestoneAtQ(level As String)
        If casparMT.IsConnected Then
            cgDataMT.SetData("secondMilestoneLevel", level)
            casparMT.Channels(moneyTreeCGchannel).CG.Update(moneyTreeCGlayer, moneyTreeCGchannel, cgDataMT)
            casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, moneyTreeCGchannel, "setSecondMilestoneLevel")
        End If
    End Sub

    Public Shared Sub removeSecondMilestone()
        If casparMT.IsConnected Then
            cgDataMT.SetData("secondMilestoneLevel", 0)
            casparMT.Channels(moneyTreeCGchannel).CG.Update(moneyTreeCGlayer, moneyTreeCGchannel, cgDataMT)
            casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, moneyTreeCGchannel, "setSecondMilestoneLevel")
        End If
    End Sub

    Public Shared Sub CGgleenQAstart()
        If casparQA.IsConnected Then
            casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "GleenQAstart")
        End If
    End Sub

    Public Shared Sub CGgleenQAstop()
        Return
        If casparQA.IsConnected Then
            casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "GleenQAstop")
        End If
    End Sub

    Public Shared Function ShowHideATAGraph() As Boolean
        If casparQA.IsConnected Then
            If flagATAgraph = False Then
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "showATAgraph")
                flagATAgraph = True
            Else
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "hideATAgraph")
                flagATAgraph = False
            End If
        End If
        Return flagATAgraph

    End Function

    Public Shared Sub resetVariables()

        flagQforGraph = False
        flagATAgraph = False
        flagLifeLineRemindGraph = False

    End Sub

    Public Shared Sub PhoneAFriend(casePAF As String)
        If casparPhoneAFriend.IsConnected Then
            Select Case casePAF
                Case "START"
                    casparPhoneAFriend.Channels(phoneAfriendCGchannel).CG.Invoke(phoneAfriendCGlayer, phoneAfriendCGchannel, "startPhoneAFriend")
                Case "ABORT"
                    casparPhoneAFriend.Channels(phoneAfriendCGchannel).CG.Invoke(phoneAfriendCGlayer, phoneAfriendCGchannel, "abortPhoneAFriend")
                Case "END"
                    casparPhoneAFriend.Channels(phoneAfriendCGchannel).CG.Invoke(phoneAfriendCGlayer, phoneAfriendCGchannel, "endPhoneAFriend")
            End Select
            'GraphicsProcessingUnit.casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "QuestionAnswersFadeIN")
        End If

    End Sub

    Public Shared Sub CGMoneyTreeDataSet(QSum1 As String, QSum2 As String, QSum3 As String, QSum4 As String, QSum5 As String, QSum6 As String, QSum7 As String, QSum8 As String, QSum9 As String, QSum10 As String, QSum11 As String, QSum12 As String, QSum13 As String, QSum14 As String, QSum15 As String, LifelinesNames As String)

        '' ******* CASPARCG ******* CASPARCG ******* CASPARCG ******* ******* CASPARCG ******* CASPARCG ******* CASPARCG *******
        If casparMT.IsConnected Then
            cgDataMT.SetData("sumq1", QSum1)
            cgDataMT.SetData("sumq2", QSum2)
            cgDataMT.SetData("sumq3", QSum3)
            cgDataMT.SetData("sumq4", QSum4)
            cgDataMT.SetData("sumq5", QSum5)
            cgDataMT.SetData("sumq6", QSum6)
            cgDataMT.SetData("sumq7", QSum7)
            cgDataMT.SetData("sumq8", QSum8)
            cgDataMT.SetData("sumq9", QSum9)
            cgDataMT.SetData("sumq10", QSum10)
            cgDataMT.SetData("sumq11", QSum11)
            cgDataMT.SetData("sumq12", QSum12)
            cgDataMT.SetData("sumq13", QSum13)
            cgDataMT.SetData("sumq14", QSum14)
            cgDataMT.SetData("sumq15", QSum15)
            cgDataMT.SetData("Lifelines_TextField", LifelinesNames)
            cgDataMT.SetData("UsedLifelines_TextField", Quiz_Operator.LifelinesState)
            cgDataMT.SetData("secondMilestoneLevel", Quiz_Operator.VariableMilestone_TextBox.Text)
            cgDataMT.SetData("reachedLevel", Math.Max(Quiz_Operator.LevelQ - 1, 0))
        End If
        If casparQA.IsConnected Then
            cgDataQA.SetData("UsedLifelines_TextField", Quiz_Operator.LifelinesState)
            casparQA.Channels(questionCGchannel).CG.Update(questionCGlayer, questionCGchannel, cgDataQA)
        End If
    End Sub

    Public Shared Sub MoneyTreeFlyIn()
        If casparMT.IsConnected Then
            casparMT.Channels(moneyTreeCGchannel).CG.Play(moneyTreeCGlayer)
            casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, moneyTreeCGchannel, "MoneyTreeFlyIN")
        End If

    End Sub

    Public Shared Sub MoneyTreeFlyOut()
        If casparMT.IsConnected Then
            casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, moneyTreeCGchannel, "MoneyTreeFlyOUT")
        End If

    End Sub

    Public Shared Sub ConnectCG(CasparServerIP_TextBox As String, ByRef CASPARCGLog_TextBox As TextBox)
        Try
            My.Settings.casparHostName = CasparServerIP_TextBox

            casparQA.Settings.Hostname = My.Settings.casparHostName
            casparQA.Settings.Port = My.Settings.casparPort
            casparQA.Connect()

            System.Threading.Thread.Sleep(300)

            casparMT.Settings.Hostname = My.Settings.casparHostName
            casparMT.Settings.Port = My.Settings.casparPort
            casparMT.Connect()

            System.Threading.Thread.Sleep(300)

            casparPhoneAFriend.Settings.Hostname = My.Settings.casparHostName
            casparPhoneAFriend.Settings.Port = My.Settings.casparPort
            casparPhoneAFriend.Connect()

            System.Threading.Thread.Sleep(300)

            If casparQA.IsConnected Then
                CASPARCGLog_TextBox.Text += "Connected with CasparCG-QA!" + vbCrLf
                casparQA.Channels(questionCGchannel).CG.Add(questionCGlayer, questionCGchannel, My.Settings.questionFlashTempl, False, cgDataQA)
            Else
                CASPARCGLog_TextBox.Text += "NOT Connected with CasparCG-QA!" + vbCrLf
                casparQA.Settings.Hostname = My.Settings.casparHostName
                casparQA.Settings.Port = My.Settings.casparPort
                casparQA.Connect()
            End If
            '''''

            System.Threading.Thread.Sleep(300)

            If casparMT.IsConnected Then
                CASPARCGLog_TextBox.Text += "Connected with CasparCG-MT!" + vbCrLf
                casparMT.Channels(moneyTreeCGchannel).CG.Add(moneyTreeCGlayer, moneyTreeCGchannel, My.Settings.moneyTreeFlashTempl, False, cgDataMT)
            Else
                CASPARCGLog_TextBox.Text += "NOT Connected with CasparCG-MT!" + vbCrLf
                casparMT.Settings.Hostname = My.Settings.casparHostName
                casparMT.Settings.Port = My.Settings.casparPort
                casparMT.Connect()
            End If

            '''''

            System.Threading.Thread.Sleep(300)

            If casparPhoneAFriend.IsConnected Then
                CASPARCGLog_TextBox.Text += "Connected with CasparCG-PAF!" + vbCrLf
                casparPhoneAFriend.Channels(phoneAfriendCGchannel).CG.Add(phoneAfriendCGlayer, phoneAfriendCGchannel, My.Settings.phoneAfriendFlashTempl, False, cgDataPhoneAFriend)
            Else
                CASPARCGLog_TextBox.Text += "NOT Connected with CasparCG-PAF!" + vbCrLf
                casparPhoneAFriend.Settings.Hostname = My.Settings.casparHostName
                casparPhoneAFriend.Settings.Port = My.Settings.casparPort
                casparPhoneAFriend.Connect()
            End If

            InteractiveWallScreenObj.Connect()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        System.Threading.Thread.Sleep(500)

    End Sub


    Public Shared Function QuestionForLozenge(QuestionForSume As String)
        If casparQA.IsConnected Then
            If flagQforGraph = False Then
                cgDataQA.SetData("QuestionFor_TextField", QuestionForSume)
                casparQA.Channels(questionCGchannel).CG.Update(questionCGlayer, questionCGchannel, cgDataQA)
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "showQforGraph")
                flagQforGraph = True
                'showQforGraph
            Else
                casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "hideQforGraph")
                'Qfor_Label.BackColor = Color.PaleGreen
                flagQforGraph = False
                'hideQforGraph
            End If
        End If
        Return flagQforGraph
    End Function

    Public Shared Sub CorrectAnswer(CorrectAnswer As String)
        If casparQA.IsConnected Then
            casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "correctAnswer" + CorrectAnswer)
        End If
    End Sub

    Public Shared Sub DobleDip(FinalAnswer As String)
        If casparQA.IsConnected Then
            casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "doubleDipAnswer" + FinalAnswer)
        End If
    End Sub

    Public Shared Sub MoneyTreeLevel(MoneyTreeLevel As String)
        Dim MoneyTreeCommandInvoke As String = "setLevelPositionQ" + MoneyTreeLevel.ToString
        If casparMT.IsConnected Then
            cgDataMT.SetData("reachedLevel", MoneyTreeLevel)
            casparMT.Channels(moneyTreeCGchannel).CG.Update(moneyTreeCGlayer, moneyTreeCGchannel, cgDataMT)
            casparMT.Channels(moneyTreeCGchannel).CG.Invoke(moneyTreeCGlayer, moneyTreeCGchannel, MoneyTreeCommandInvoke)
        End If
    End Sub

    Public Shared Sub WalkAwayQoppinion()
        '' ******* CASPARCG ******* CASPARCG ******* CASPARCG *******
        If casparQA.IsConnected Then
            'casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "QuestionShow_Label") 'QuestionShow_Label 'casparQA_.Channels(0).CG.Invoke(1, "QuestionABCD_Label")
            'casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "QuestionAnswersFlyIN")
            casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "QuestionABCD_Label")
            casparQA.Channels(questionCGchannel).CG.Invoke(questionCGlayer, questionCGchannel, "returnAnswersABCD")
            casparQA.Channels(questionCGchannel).CG.Play(questionCGlayer)
            'casparQA_.Channels(0).CG.Invoke(1, "fitSizeOFTexts")
        End If
    End Sub

    Public Shared Sub MoneyTreeSet()
        If casparMT.IsConnected Then

            casparMT.Channels(moneyTreeCGchannel).CG.Play(moneyTreeCGlayer)
            casparMT.Channels(moneyTreeCGchannel).CG.Update(moneyTreeCGlayer, moneyTreeCGchannel, cgDataMT)
        End If

    End Sub

End Class
