# PDFUserControl Usage Guide
The PDFUserControl is a custom user control designed for viewing and interacting with PDF documents within a C# WPF application. This guide provides an overview of the functions and properties available when using this control.

## Table of Contents

1. [Usage](#usage)
   - [Basic Functions](#basic-functions)
     - [Opening a PDF File](#pdfvieweropenfilestring-filepath)
   - [Navigating Pages](#navigating-pages)
     - [Going to the Next Page](#pdfviewergonextpage)
     - [Going to the Previous Page](#pdfviewergopreviouspage)
     - [Going to a Specific Page](#pdfviewergotopage)
   - [Zooming](#zooming)
     - [Setting Zoom Level](#pdfviewerzoomdouble-zoomfactor)
     - [Zooming to Fit Width](#pdfviewerzoomtowidth)
     - [Zooming to Fit Height](#pdfviewerzoomtoheight)
   - [Page Display](#page-display)
     - [Setting Page Row Display Type](#pdfviewersetpagerowdisplaysystemdatamoonpdfwpfpagerowdisplaytypecontinuouspagerows-singlepagerow)
     - [Setting View Type](#pdfviewersetviewtypesystemdatamoonpdfwpfviewtypesinglepage-facing-bookview)
   - [Event Handling](#event-handling)
     - [Subscribing to PageChanged Event](#subscribing-to-pagechanged-event)
2. [Additional Notes](#additional-notes)
3. [License](#license)


# Usage
To get started, initialize an instance of the PDFUserControl:

```csharp
PDFUserControl pdfViewer = new PDFUserControl();
```
## Basic Functions
### pdfViewer.OpenFile(string filePath);
To begin viewing a PDF, you can use the OpenFile method to load a PDF file:

```csharp
pdfViewer.OpenFile(@"C:\Users\90543\Downloads\yokAcikBilim_10288855.pdf");
```
## Navigating Pages
You can navigate through the pages of the PDF using the following methods:

### pdfViewer.GoNextPage();

```csharp
pdfViewer.GoNextPage();
```
### pdfViewer.GoPreviousPage();
```csharp
pdfViewer.GoPreviousPage();
```
### pdfViewer.GoToPage(); 

```csharp
pdfViewer.GoToPage(2); // Navigate to page 2
```
## Zooming
You can control the zoom level of the PDF:

### pdfViewer.Zoom(double zoomFactor); 

```csharp
pdfViewer.Zoom(2.0); // Zooming to a specific zoom factor (0 to 6)
```

### pdfViewer.ZoomToWidth()

```csharp
pdfViewer.ZoomToWidth(); // Zooming to fit the width of the page
```

### pdfViewer.ZoomToHeight();
```csharp
pdfViewer.ZoomToHeight(); //Zooming to fit the height of the page
```

## Page Display
You can control how multiple pages are displayed:

Setting the page row display type:

```csharp
pdfViewer.SetPageRowDisplay(System.Data.MoonPdf.Wpf.PageRowDisplayType.ContinuousPageRows); // SinglePageRow 
```
```csharp
pdfViewer.SetViewType(System.Data.MoonPdf.Wpf.ViewType.SinglePage); // Facing, BookView
```
Event Handling
You can subscribe to the PageChanged event to be notified when the current page changes:

```csharp
pdfViewer.PageChanged += (sender, pageNumber) =>
{
    Console.WriteLine($"Page Changed: {pageNumber}");
};
```
## Additional Notes
The PDFUserControl relies on the moonPdfPanel control to display and interact with PDF content. You can customize the behavior and appearance of the moonPdfPanel as needed.

Be sure to implement error handling, especially when dealing with sensitive data like file paths.

This guide provides a basic overview of how to use the PDFUserControl for viewing and interacting with PDF documents in your C# WPF application. For more advanced usage scenarios, consult the documentation for the moonPdfPanel and PDFUserControl classes.
### License
[MIT](https://choosealicense.com/licenses/mit/)