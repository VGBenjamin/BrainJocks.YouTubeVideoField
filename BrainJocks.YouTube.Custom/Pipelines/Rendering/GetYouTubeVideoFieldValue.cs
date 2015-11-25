using System;
using BrainJocks.YouTube.Custom.FieldTypes;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.RenderField;

namespace BrainJocks.YouTube.Custom.Pipelines.Rendering
{
    internal class GetYouTubeVideoFieldValue
    {
        public void Process(RenderFieldArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            string fieldTypeKey = args.FieldTypeKey;
            if (fieldTypeKey != "youtubevideo") return;

            args.DisableWebEditContentEditing = true;
            YouTubeVideoField video = args.GetField();

            if (Context.PageMode.IsPageEditorEditing)
            {
                YouTubeVideoField.ThumbnailSize size;
                Enum.TryParse(args.Parameters["Size"], out size); // default is Small                

                args.Result.FirstPart = YouTubeVideoField.FormatValueForPageEditorDisplay(video.Value, size);
            }
            else
            {
                byte autoHide = GetByteOrDefault(args.Parameters["autohide"], 2);
                bool autoPlay = GetBoolOrDefault(args.Parameters["autoplay"]);
                byte controls = GetByteOrDefault(args.Parameters["controls"], 1);
                bool loop = GetBoolOrDefault(args.Parameters["loop"]);
                bool rel = GetBoolOrDefault(args.Parameters["rel"]);
                bool showinfo = GetBoolOrDefault(args.Parameters["showinfo"]);
                int start = GetIntOrDefault(args.Parameters["start"]);

                args.Result.FirstPart = video.FormatValueForNormalDisplay(video.Value, autoHide, autoPlay, controls, loop, rel, showinfo, start);
            }

        }

        public static bool GetBoolOrDefault(string s, bool @default = false)
        {
            bool b;
            return bool.TryParse(s, out b) ? b : @default;
        }

        public static byte GetByteOrDefault(string s, byte @default = 0)
        {
            byte b;
            return byte.TryParse(s, out b) ? b : @default;
        }

        public static int GetIntOrDefault(string s, int @default = 0)
        {
            int b;
            return int.TryParse(s, out b) ? b : @default;
        }
    }
}