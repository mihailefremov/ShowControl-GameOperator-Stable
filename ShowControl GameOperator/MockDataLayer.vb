Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class MockDataLayer
    Implements IQuizShowDataLayer

    Public Sub DisposeAnsweredGameQuestions(QuestionType As String) Implements IQuizShowDataLayer.DisposeAnsweredGameQuestions
        Return
    End Sub

    Public Sub DisposeATAvoteData() Implements IQuizShowDataLayer.DisposeATAvoteData
        Return
    End Sub

    Public Sub MarkQuestionAnswered(questionID As String, IsGameGoingLive As Boolean) Implements IQuizShowDataLayer.MarkQuestionAnswered
        Return
    End Sub

    Public Sub MarkQuestionFired(questionID As String, IsGameGoingLive As Boolean, Optional qtype As String = "1") Implements IQuizShowDataLayer.MarkQuestionFired
        Return
    End Sub

    Public Function GetATAvoteData() As String() Implements IQuizShowDataLayer.GetATAvoteData
        Return {"0", "0", "0", "0"}
    End Function

    Public Function SelectSuitableQuestion(questionLevel As String, Optional typeQ As String = "1", Optional isReplacement As Boolean = False) As DataTable Implements IQuizShowDataLayer.SelectSuitableQuestion
        Dim dbDataTable As New DataTable
        dbDataTable.Columns.Add("Question")
        dbDataTable.Columns.Add("Answer1")
        dbDataTable.Columns.Add("Answer2")
        dbDataTable.Columns.Add("Answer3")
        dbDataTable.Columns.Add("Answer4")
        dbDataTable.Columns.Add("CorrectAnswer")
        dbDataTable.Columns.Add("MoreInformation")
        dbDataTable.Columns.Add("Pronunciation")
        dbDataTable.Columns.Add("QuestionID")
        dbDataTable.Rows.Add()

        Dim QuestionText As String = "Question:" + questionLevel + vbCrLf + "Question:" + questionLevel
        Dim Answer1Text As String = "Answer 1" + " Qnr:" + questionLevel
        Dim Answer2Text As String = "Answer 2" + " Qnr:" + questionLevel
        Dim Answer3Text As String = "Answer 3" + " Qnr:" + questionLevel
        Dim Answer4Text As String = "Answer 4" + " Qnr:" + questionLevel
        Dim CorrectAnswer As String = New Random().Next(1, 5).ToString
        Dim Explanation As String = "Explanation" + " Qnr:" + questionLevel
        Dim Pronunciation As String = "Pronunciation" + " Qnr:" + questionLevel
        Dim questionID As Integer = Integer.MinValue

        With dbDataTable
            .Rows(0)("Question") = QuestionText
            .Rows(0)("Answer1") = Answer1Text
            .Rows(0)("Answer2") = Answer2Text
            .Rows(0)("Answer3") = Answer3Text
            .Rows(0)("Answer4") = Answer4Text
            .Rows(0)("CorrectAnswer") = CorrectAnswer
            .Rows(0)("MoreInformation") = Explanation
            .Rows(0)("Pronunciation") = Pronunciation
            .Rows(0)("QuestionID") = questionID
        End With
        dbDataTable.AcceptChanges()

        Return dbDataTable

    End Function
End Class
