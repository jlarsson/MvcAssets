## Summary
Javascript and CSS asset manager.

## Installation

<div style="background:#d6d6d6;border:0px solid #fff;padding:4px;margin: 36px 0;filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=0, startColorstr='#d6d6d6',  endColorstr='#505050');background: -webkit-gradient(linear, 0 0, 0 100%, from(#d6d6d6), to(#505050));background: -moz-linear-gradient(top, #d6d6d6, #505050);border-radius: 8px;-webkit-border-radius: 8px;-moz-border-radius: 8px;">
<div style="background:#000;border:1px solid #c4c4c4;text-shadow: 1px 1px 1px rgba(0, 0, 0 ,1.0);filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=0, startColorstr='#5e5e5e',  endColorstr='#000');background: -webkit-gradient(linear, 0 0, 0 100%, from(#5e5e5e), to(#000));background: -moz-linear-gradient(top, #5e5e5e, #000);box-shadow: inset 6px 6px 14px rgba(0, 0, 0, 0.6), 1px 1px 4px rgba(102, 102, 102, 1.0);-webkit-box-shadow: inset 6px 6px 14px rgba(0, 0, 0, 0.6), 1px 1px 4px rgba(102, 102, 102, 1.0); -moz-box-shadow: inset 6px 6px 14px rgba(0, 0, 0, 0.6), 1px 1px 4px rgba(102, 102, 102, 1.0);border-radius: 6px;-webkit-border-radius: 6px;-moz-border-radius: 6px;">
  <p style="color:#e2e2e2;font-size:24px;line-height:24px;margin:24px 8px;">
		PM&gt; Install-Package MvcAssets
	</p>
</div>
</div>

Optionally, if you need compression and combining of assets, use

<div style="background:#d6d6d6;border:0px solid #fff;padding:4px;margin: 36px 0;filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=0, startColorstr='#d6d6d6',  endColorstr='#505050');background: -webkit-gradient(linear, 0 0, 0 100%, from(#d6d6d6), to(#505050));background: -moz-linear-gradient(top, #d6d6d6, #505050);border-radius: 8px;-webkit-border-radius: 8px;-moz-border-radius: 8px;">
<div style="background:#000;border:1px solid #c4c4c4;text-shadow: 1px 1px 1px rgba(0, 0, 0 ,1.0);filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=0, startColorstr='#5e5e5e',  endColorstr='#000');background: -webkit-gradient(linear, 0 0, 0 100%, from(#5e5e5e), to(#000));background: -moz-linear-gradient(top, #5e5e5e, #000);box-shadow: inset 6px 6px 14px rgba(0, 0, 0, 0.6), 1px 1px 4px rgba(102, 102, 102, 1.0);-webkit-box-shadow: inset 6px 6px 14px rgba(0, 0, 0, 0.6), 1px 1px 4px rgba(102, 102, 102, 1.0); -moz-box-shadow: inset 6px 6px 14px rgba(0, 0, 0, 0.6), 1px 1px 4px rgba(102, 102, 102, 1.0);border-radius: 6px;-webkit-border-radius: 6px;-moz-border-radius: 6px;">
	<p style="color:#e2e2e2;font-size:24px;line-height:24px;margin:24px 8px;">
		PM&gt; Install-Package MvcAssets.Compress
	</p>
</div>
</div>

## Requirements

* .NET 4.0
* ASP.NET MVC 3

##Key features

* Automatic handling of dulicate inline scripts, inline styles, javascript includes and css includes.
* Best practice rendering of assets in either head or footer of page.
* Allows references to assets in master views, views and partial views without risk of clobbering generated markup
* Minification and combination of javascript and css files (via [AjaxMin](http://http://ajaxmin.codeplex.com))

## Legal

MvcAssets is released under the [MIT License](http://www.opensource.org/licenses/mit-license.php).

AjaxMin is released under the [Apache License](http://ajaxmin.codeplex.com/license)

## Contribute

Contributors are welcome. Create a fork on github and send me pull requests.
