# Blazor.Page
Page base component for Blazor pages. Easily update page title and optionally inject data context into your page.

![](https://mikaelkoskinen.net/posts/files/695ca323-da9e-4ea1-9f54-e19ce0aa955a.gif)

Blazor.Page is a Blazor component, designed to be used as the base component for your Blazor Pages. It offers two features for your pages:

* Ability to set and get page title
* (Optionally) Ability to set data context for your page. Data context can be used similar to ViewModels in MVVM or similar to PageModels in Razor Pages.

This release has been tested with the server side version of .NET Core v3.0.0-rc1 Blazor.

[![NuGet](https://img.shields.io/nuget/v/Page.Blazor.svg)](https://www.nuget.org/packages/Page.Blazor/)

## Introduction

For a more throughout introduction of the control, please see the following introduction post: https://mikaelkoskinen.net/post/blazor-page-change-title

## Getting Started

To get started, install the Nuget-package Page.Blazor.

Then, include the required Javascript-interop –library. If your only going to use the data context-feature of the page component, this isn’t needed. The JS-file should be included in the _Host.cshtml:

```
<script src="_content/Page.Blazor/blazorPageInterop.js"></script>
```

And your done. The next job is creating a new page which inherits Blazor.Page.Page:

```
@page "/"
@inherits Blazor.Page.Page
```

And now you can use your page to edit the title (HTML title tag) through Title-property:

```
public void Update()
{
    this.Title = NewTitle;
}
```
## Using the data context

The idea behind the data context comes from WPF/Silverlight, where DataContext-property was used in MVVM-scenarios. Blazor.Page provides a way of creating a PageModel/ViewModel for you page by offering an abstract PageModelBase-class.

For a full sample, please see the samples-folder.

## Background ##
Not all Blazor components should be treated equal. Some components are used as Button-replacements. Some provide wrappers for Bootstrap controls. Pages are one of the special cases where I think a different base class is required. Pages are often long-lived and they are more than just controls.

Blazor doesn’t currently support “native” or built-in way of changing the HTML page’s title. This library aims to make it as easy as possible. Also, coming from MVVM and Razor Pages, it’s often desired to separate the View and the Model. This library allows you to inject a PageModel/ViewModel into your page as a data context. PageModel can be used to “offload” the functionality from the view.

## Requirements ##
The library has been developed and tested using the following tools:

.NET Core 3.0 RC 1
Visual Studio 2019 Preview
Server side Blazor
