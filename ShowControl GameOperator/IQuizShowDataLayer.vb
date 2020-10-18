Public Interface IQuizShowDataLayer
    Sub DisposeAnsweredGameQuestions(QuestionType As String)
    Sub DisposeATAvoteData()
    Sub MarkQuestionAnswered(questionID As String, IsGameGoingLive As Boolean)
    Sub MarkQuestionFired(questionID As String, IsGameGoingLive As Boolean, Optional qtype As String = "1")
    Function GetATAvoteData() As String()
    Function SelectSuitableQuestion(questionLevel As String, Optional typeQ As String = "1", Optional isReplacement As Boolean = False) As DataTable
End Interface
