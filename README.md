# YouTube Video Picker Field for Sitecore 

Also avaialble [in the Sitecore Marketplace](http://marketplace.sitecore.net/en/Modules/YouTube_Video_Picker_Field.aspx)

Building a custom field type in Sitecore with support for Content and Page Editor isn’t particularly hard. Specifically, for a “picker” field you would need:

* New field type definition in the `core` database
* New field type backing class
* Content Editor control with `select` and `clear` message handlers
* XML control (markup and codebeside) that renders the ‘picker’ dialog
* WebEdit command for Page Editor
* A `renderField` pipeline extension to customize how field value renders in Page Editor
* A `renderContentEditor` pipeline extension to bring in extra resources into Content Editor

Here at [BrainJocks](http://www.brainjocks.com/) we have recently created a few of these experiences and decided to open source one - *YouTube Video Picker*. 

It’s a fully workable solution. Feel free to use it in your project or explore as a study guide. We also published a series of blog posts about it:

* Part 1 - http://jockstothecore.com/youtube-video-picker-part-1-introduction/
* Part 2 - http://jockstothecore.com/youtube-video-picker-part-2-prototype/
* Part 3 - http://jockstothecore.com/youtube-video-picker-part-3-sitecore-citizenship/
* Part 4 - http://jockstothecore.com/youtube-video-picker-part-4-xml-control/

# Install

The project uses [TDS](http://www.hhogdev.com/products/team-development-for-sitecore/overview.aspx) and is structured the way we structure all our Sitecore projects (more details here - [part 1](http://jockstothecore.com/setting-up-a-sitecore-solution-part-1-visual-studio-and-projects/), [part 2](http://jockstothecore.com/setting-up-a-sitecore-solution-part-2-tds-and-build-configurations/)). Once you pull it down please:

[More installation and configuration instructions](Release).

# Use

The raw value of the field is the YouTube video ID so you can render it any way you like on the actual website. Content Editor experience is built-in. When it comes to Page Editor, the pipeline extensions will do all the work so all you do is:

```
@Html.Sitecore().Field("Video One")
```

to render a default (small) thumbnail or:

```
@Html.Sitecore().Field("Video One", new { Size = YouTubeVideoField.ThumbnailSize.Medium})
```

to specify the size of how you like the thumbnail rendered. 


```
@Html.Sitecore().Field("Video One", new { ParamName = Value})
```

to specify additional parameters from this doc https://developers.google.com/youtube/player_parameters
We handle the following parameters:

* autoHide
* autoPlay
* controls
* loop
* rel
* showinfo
* start

> We are 100% MVC with Sitecore but the field type itself has no MVC dependency and can be as easily used with other rendering technologies

The [TDS.Master](https://github.com/pveller/BrainJocks.YouTubeVideoField/tree/master/BrainJocks.YouTube.TDS.Master) and [TDS.Master.Content](https://github.com/pveller/BrainJocks.YouTubeVideoField/tree/master/BrainJocks.YouTube.TDS.Master.Content) projects have Sitecore definition items for a very basic demonstration. Install it on top of a vanilla Sitecore installation and your `Home` item will have two additional youtube fields and customized layout details ([layout](https://github.com/pveller/BrainJocks.YouTubeVideoField/blob/master/BrainJocks.YouTube.Web/Areas/Test/Views/Layouts/TestVideoFieldLayout.cshtml) and [rendering](https://github.com/pveller/BrainJocks.YouTubeVideoField/blob/master/BrainJocks.YouTube.Web/Areas/Test/Views/_TestVideoField.cshtml))