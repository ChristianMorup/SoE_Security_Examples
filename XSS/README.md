# Guide

This project consists of a Razor Page with a Search field that is vulnerable to a simple XSS attack. 

## Implementation
- The code takes the search term from the page and constructs a HTML-formatted output containing the search term. 
- No actual searching is performed. However, for the sake of argument, this is a good enough example since a search output often would contain the search input.

## Performing the attack
When starting the application, this page is shown: 
![Page](images/page.png?raw=true "Title")

To perform the XSS attack, search with the following search term:
```
<script>alert('Hacked!!')</script>
```

The following modal appears: 
![PageHacked](images/page_hacked.png?raw=true "Title")


## What went wrong?
Looking at the source (generated HTML) in the browser, we will see this following fragment within the page:
```
<div class="row">
    <div class="col-md-12">
        Your search for <i><script>alert('Hacked!!')</script></i> did not yield any results
    </div>
</div>
```
This is the result of the user sending a search term to the server and the server responding with HTML that contained "You searched for \<search term>", but with the attack contained in the angle brackets \< >. The browser interprets this search term as HTML markup, which enables an attacker successfully inject JavaScript.

## How to mitigate in ASP.NET?
Do not use @Html.Raw() unless you are absolutely certain that the data you are outputting could not have been supplied or manipulated by the user. Otherwise, you are prone to XSS. 

