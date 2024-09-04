<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128611530/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T384347)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Rich Text Editor - How to Use the Document Iterator Object to Iterate over Document Elements

The following example shows how to use the Visitor-Iterator pattern to format document text:

* Enclose bold text in asterisks
* Return all characters without formatting
* Replace paragraph ends with newline symbols

Other document elements are skipped.

## Implementation Details

This example creates a [DocumentIterator](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Native.DocumentIterator) instance for the current document and calls its [MoveNext](https://docs.devexpress.com/OfficeFileAPI/devexpress.xtrarichedit.api.native.documentiterator.movenext.overloads) method to iterate over document elements.

A **Visitor** pattern is implemented to process a document element. The implementation is done by calling each element's [Accept](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Native.IDocumentElement.Accept(DevExpress.XtraRichEdit.API.Native.IDocumentVisitor)) method with the **MyVisitor** object instance as a parameter.

`MyVisitor` is a custom class that descends from the [DocumentVisitorBase](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Native.DocumentVisitorBase) class. It contains a method that processes [DocumentText](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Native.DocumentText) elements to enclose bold text in asterisks and return all characters without formatting. Paragraph ends are replaced with newline symbols, other document elements are skipped.

## Files to Review

* [Form1.cs](./CS/DocumentIteratorExample/Form1.cs) (VB: [Form1.vb](./VB/DocumentIteratorExample/Form1.vb))

## Documentation

* [How to: Retrieve the List of Document Fonts using the Visitor-Iterator Pattern](https://docs.devexpress.com/WindowsForms/116746/controls-and-libraries/rich-text-editor/examples/automation/how-to-retrieve-the-list-of-document-fonts-using-the-visitor-iterator-pattern)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-richedit-iterate-over-document-elements&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-richedit-iterate-over-document-elements&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
