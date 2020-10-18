Imports Svt.Caspar

Public Class InteractiveWallScreen

    Private casparWallScreen As New CasparDevice
    Private cgDataWallScreen As New CasparCGDataCollection

    Public IsOnWallScreen As Boolean = My.Settings.IsInteractiveScreenOn

    Private WallScreenConfigurationTxt As String
    Private WallScreenConfiguration As Xml2CSharp.INTERACTIVEWALLSCREEN

    Public Sub Connect()
        If Not IsOnWallScreen Then
            Return
        End If
        Try
            System.Threading.Thread.Sleep(300)
            casparWallScreen.Settings.Hostname = My.Settings.casparHostName
            casparWallScreen.Settings.Port = My.Settings.casparPort
            casparWallScreen.Connect()
        Catch ex As Exception
        End Try

    End Sub

    Sub LightDownEffect(Level As String)
        WallScreenBackgroundPlay("LightsDown", Level)

    End Sub

    Public Sub MotionBackgroundDuringQuestion(Level As String)
        If Level = 2001 Then
            Level = "FastestFingerFirst"
        ElseIf Level = 2002 Then
            Level = "Other"
        ElseIf Level = 666 Then
            Level = "WalkAway"
        End If
        WallScreenBackgroundPlay("QuestionBed", Level)
    End Sub

    Public Sub CorrectAnswer(Level As String)
        Dim discarValue As Integer = 0
        If Integer.TryParse(Level, discarValue) Then
            discarValue -= 1
        End If
        WallScreenBackgroundPlay("CorrectAnswer", discarValue)
    End Sub

    Public Sub AudienceAsking()
        WallScreenBackgroundPlay("AudienceAsking")

    End Sub

    Public Sub AudienceVoting()
        WallScreenBackgroundPlay("AudienceVoting")

    End Sub

    Public Sub HostEntrance()
        WallScreenBackgroundPlay("HostEntrance")

    End Sub

    Public Sub AnyBackgroundLoop(bed As String)
        WallScreenBackgroundPlay(bed)

    End Sub

    Public Function LoadWallScreenConfiguration(path As String) As Boolean
        Try
            WallScreenConfigurationTxt = System.IO.File.ReadAllText(path)

            Dim WallScreenConfigurationReader As System.IO.TextReader = New System.IO.StringReader(WallScreenConfigurationTxt)

            Dim serializer As Xml.Serialization.XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(Xml2CSharp.INTERACTIVEWALLSCREEN))
            WallScreenConfiguration = serializer.Deserialize(WallScreenConfigurationReader)

            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return False

    End Function

    Public Function WallScreenBackgroundPlay(State As String, Optional Level As String = "") As Boolean
        If Not IsOnWallScreen Then
            Return False
        End If

        Try
            For Each configuredGamePart As Xml2CSharp.GAMEPART In WallScreenConfiguration.GAMEPART
                If String.Equals(configuredGamePart.STATE, State) Then
                    configuredGamePart.AFFECTEDLEVELS = configuredGamePart.AFFECTEDLEVELS.Trim.Replace(" ", "").Replace(",", ";")
                    Dim configuredGamePartAffectedLevels As String() = configuredGamePart.AFFECTEDLEVELS.Split(";")
                    If configuredGamePartAffectedLevels.Count = 0 Then configuredGamePartAffectedLevels = {""}

                    For Each configuredGamePartLevel As String In configuredGamePartAffectedLevels
                        If String.Equals(configuredGamePartLevel, Level, StringComparison.OrdinalIgnoreCase) Then

                            Dim index As Integer = New Random().Next(configuredGamePart.BACKGROUNDS.VIDEO.Count) 'get random video
                            Dim selectedVideo As Xml2CSharp.VIDEO = configuredGamePart.BACKGROUNDS.VIDEO.ElementAt(index)

                            Dim isLoop As Boolean = False
                            selectedVideo.LOOP = selectedVideo.LOOP.Trim
                            If String.Equals(selectedVideo.LOOP, "True", StringComparison.OrdinalIgnoreCase) _
                                OrElse String.Equals(selectedVideo.LOOP, "Yes", StringComparison.OrdinalIgnoreCase) _
                                    OrElse String.Equals(selectedVideo.LOOP, "1", StringComparison.OrdinalIgnoreCase) Then
                                isLoop = True
                            End If

                            If casparWallScreen.IsConnected Then
                                casparWallScreen.Channels(0).Clear(0)
                                casparWallScreen.Channels(0).LoadBG(20, selectedVideo.URL, isLoop)
                                casparWallScreen.Channels(0).SetVolume(20, 0, 8, Easing.EaseInBack)
                                casparWallScreen.Channels(0).Play(20)
                            End If

                            Exit For
                        Else
                            Continue For
                        End If
                    Next

                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

End Class
