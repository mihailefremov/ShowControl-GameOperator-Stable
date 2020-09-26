Imports System
Imports System.Xml.Serialization
Imports System.Collections.Generic

Namespace Xml2CSharp
    <XmlRoot(ElementName:="VIDEO")>
    Public Class VIDEO
        <XmlElement(ElementName:="URL")>
        Public Property URL As String
        <XmlElement(ElementName:="LOOP")>
        Public Property [LOOP] As String
    End Class

    <XmlRoot(ElementName:="BACKGROUNDS")>
    Public Class BACKGROUNDS
        <XmlElement(ElementName:="VIDEO")>
        Public Property VIDEO As List(Of VIDEO)
    End Class

    <XmlRoot(ElementName:="GAMEPART")>
    Public Class GAMEPART
        <XmlElement(ElementName:="STATE")>
        Public Property STATE As String
        <XmlElement(ElementName:="AFFECTEDLEVELS")>
        Public Property AFFECTEDLEVELS As String
        <XmlElement(ElementName:="DESCRIPTION")>
        Public Property DESCRIPTION As String
        <XmlElement(ElementName:="BACKGROUNDS")>
        Public Property BACKGROUNDS As BACKGROUNDS
        <XmlElement(ElementName:="RANDOMIZE")>
        Public Property RANDOMIZE As String
    End Class

    <XmlRoot(ElementName:="INTERACTIVEWALLSCREEN")>
    Public Class INTERACTIVEWALLSCREEN
        <XmlElement(ElementName:="GAMEPART")>
        Public Property GAMEPART As List(Of GAMEPART)
    End Class
End Namespace
