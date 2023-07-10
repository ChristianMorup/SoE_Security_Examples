# Guide

This project consists of a ASP.NET Core MVC project with a JSON endpoint implemented.

## Implementation
- The SearchAPI endpoint takes a search term, generates some dummy search results, and is then essentially using string concatenation to create a JSON representation of those search terms.
- No actual searching is performed. However, for the sake of argument, this is a good enough example since a search output often would contain the search input.

## Performing the attack
When starting the application and entering ``` <script>alert('Hacked!!')</script> ``` into the search field, the search seems to work and it prevents the XSS-attack as seen below:

![Page](images/page.png?raw=true "Title")

Even though the search term has a \<script> tag, the browser does not execute it after it is dynamically added to the page. 
However, this does not mean that we are protected against XSS. When accessing ``` https://localhost:7017/Home/SearchAPI?searchTerm=%3Cscript%3Ealert(%27Hacked!%27)%3C/script%3E ``` the JavaScript code is executed. 

![Page](images/page_hacked.png?raw=true "Title")


## What went wrong?
Even though the JSON code from the search API below is valid and unproblematic in a JSON context, it is still able to be interpreted in as HTML. 
```
[
    "<script>alert('Hacked!!')</script> 1",
    "<script>alert('Hacked!!')</script> 2",
    "<script>alert('Hacked!!')</script> 3",
]
```
This exploit is easy to use in links. 