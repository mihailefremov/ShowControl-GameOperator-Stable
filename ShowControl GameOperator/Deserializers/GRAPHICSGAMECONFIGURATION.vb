Imports System
Imports System.Xml.Serialization
Imports System.Collections.Generic

Namespace Xml2CSharp
    <XmlRoot(ElementName:="CONFIGURATION")>
    Public Class CONFIGURATION
        <XmlElement(ElementName:="STATE")>
        Public Property STATE As String
        <XmlElement(ElementName:="CASE")>
        Public Property [CASE] As String
        <XmlElement(ElementName:="AFFECTEDLEVELS")>
        Public Property AFFECTEDLEVELS As String
        <XmlElement(ElementName:="AUTOSHOW")>
        Public Property AUTOSHOW As String
        <XmlElement(ElementName:="MILISECONDSTOSHOW")>
        Public Property MILISECONDSTOSHOW As String
        <XmlElement(ElementName:="AUTOREMOVE")>
        Public Property AUTOREMOVE As String
        <XmlElement(ElementName:="MILISECONDSTOREMOVE")>
        Public Property MILISECONDSTOREMOVE As String
        <XmlElement(ElementName:="BARHOP")>
        Public Property BARHOP As String
        <XmlElement(ElementName:="MILISECONDSBETWEENHOP")>
        Public Property MILISECONDSBETWEENHOP As String
        <XmlElement(ElementName:="LIFELINESPING")>
        Public Property LIFELINESPING As String
        <XmlElement(ElementName:="INCLUDEEXTRALIFELINE")>
        Public Property INCLUDEEXTRALIFELINE As String
    End Class

    <XmlRoot(ElementName:="GRAPHICSGAMECONFIGURATION")>
    Public Class GRAPHICSGAMECONFIGURATION
        <XmlElement(ElementName:="CONFIGURATION")>
        Public Property CONFIGURATION As List(Of CONFIGURATION)
    End Class
End Namespace
