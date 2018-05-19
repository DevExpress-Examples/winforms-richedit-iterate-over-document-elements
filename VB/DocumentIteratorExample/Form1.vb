Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DocumentIteratorExample
    Partial Public Class Form1
        Inherits DevExpress.XtraBars.Ribbon.RibbonForm

        Public Sub New()
            InitializeComponent()
            ribbonControl1.SelectedPage = pageIterator
        End Sub

        Private Sub btnIteratorRun_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnIteratorRun.ItemClick
'            #Region "#runvisitor"
            Dim visitor As New MyVisitor()
            Dim iterator As New DocumentIterator(richEditControl1.Document, True)
            Do While iterator.MoveNext()
                iterator.Current.Accept(visitor)
            Loop
            memoEdit1.Text = visitor.Text
'            #End Region ' #runvisitor
        End Sub
    End Class
    #Region "#myvisitorclass"
    Public Class MyVisitor
        Inherits DocumentVisitorBase


        Private ReadOnly buffer_Renamed As StringBuilder
        Public Sub New()
            Me.buffer_Renamed = New StringBuilder()
        End Sub
        Protected ReadOnly Property Buffer() As StringBuilder
            Get
                Return buffer_Renamed
            End Get
        End Property
        Public ReadOnly Property Text() As String
            Get
                Return ToString()
            End Get
        End Property

        Public Overrides Sub Visit(ByVal text As DocumentText)
            Dim prefix As String = If(text.TextProperties.FontBold, "**", "")
            Buffer.Append(prefix)
            Buffer.Append(text.Text)
            Buffer.Append(prefix)
        End Sub
        Public Overrides Sub Visit(ByVal paragraphEnd As DocumentParagraphEnd)
            Buffer.AppendLine()
        End Sub
    End Class
    #End Region ' #myvisitorclass
End Namespace
