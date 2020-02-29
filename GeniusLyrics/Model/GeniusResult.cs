using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GeniusLyrics.Model
{
    

    public partial class GeniusResult
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("response")]
        public Response Response { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("status")]
        public long Status { get; set; }
    }

    public partial class Response
    {
        [JsonProperty("sections")]
        public List<Section> Sections { get; set; }
    }

    public partial class Section
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("hits")]
        public List<Hit> Hits { get; set; }
    }

    public partial class Hit
    {
        [JsonProperty("highlights")]
        public List<Highlight> Highlights { get; set; }

        [JsonProperty("index")]
        public TypeEnum Index { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; }
    }

    public partial class Highlight
    {
        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("snippet")]
        public bool Snippet { get; set; }

        [JsonProperty("ranges")]
        public List<Range> Ranges { get; set; }
    }

    public partial class Range
    {
        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("end")]
        public long End { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("_type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("annotation_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? AnnotationCount { get; set; }

        [JsonProperty("api_path")]
        public string ApiPath { get; set; }

        [JsonProperty("full_title", NullValueHandling = NullValueHandling.Ignore)]
        public string FullTitle { get; set; }

        [JsonProperty("header_image_thumbnail_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri HeaderImageThumbnailUrl { get; set; }

        [JsonProperty("header_image_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri HeaderImageUrl { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("instrumental", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Instrumental { get; set; }

        [JsonProperty("lyrics_owner_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? LyricsOwnerId { get; set; }

        [JsonProperty("lyrics_state", NullValueHandling = NullValueHandling.Ignore)]
        public LyricsState? LyricsState { get; set; }

        [JsonProperty("lyrics_updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public long? LyricsUpdatedAt { get; set; }

        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        [JsonProperty("pyongs_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? PyongsCount { get; set; }

        [JsonProperty("song_art_image_thumbnail_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri SongArtImageThumbnailUrl { get; set; }

        [JsonProperty("song_art_image_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri SongArtImageUrl { get; set; }

        [JsonProperty("stats", NullValueHandling = NullValueHandling.Ignore)]
        public Stats Stats { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("title_with_featured", NullValueHandling = NullValueHandling.Ignore)]
        public string TitleWithFeatured { get; set; }

        [JsonProperty("updated_by_human_at", NullValueHandling = NullValueHandling.Ignore)]
        public long? UpdatedByHumanAt { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("primary_artist", NullValueHandling = NullValueHandling.Ignore)]
        public Artist PrimaryArtist { get; set; }

        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ImageUrl { get; set; }

        [JsonProperty("index_character", NullValueHandling = NullValueHandling.Ignore)]
        public string IndexCharacter { get; set; }

        [JsonProperty("is_meme_verified", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsMemeVerified { get; set; }

        [JsonProperty("is_verified", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsVerified { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [JsonProperty("cover_art_thumbnail_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri CoverArtThumbnailUrl { get; set; }

        [JsonProperty("cover_art_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri CoverArtUrl { get; set; }

        [JsonProperty("name_with_artist", NullValueHandling = NullValueHandling.Ignore)]
        public string NameWithArtist { get; set; }

        [JsonProperty("release_date_components", NullValueHandling = NullValueHandling.Ignore)]
        public ReleaseDateComponents ReleaseDateComponents { get; set; }

        [JsonProperty("artist", NullValueHandling = NullValueHandling.Ignore)]
        public Artist Artist { get; set; }

        [JsonProperty("article_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ArticleUrl { get; set; }

        [JsonProperty("author_list_for_display", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorListForDisplay { get; set; }

        [JsonProperty("dek", NullValueHandling = NullValueHandling.Ignore)]
        public string Dek { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("dfp_kv", NullValueHandling = NullValueHandling.Ignore)]
        public List<DfpKv> DfpKv { get; set; }

        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public long? Duration { get; set; }

        [JsonProperty("poster_attributes", NullValueHandling = NullValueHandling.Ignore)]
        public PosterAttributes PosterAttributes { get; set; }

        [JsonProperty("poster_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri PosterUrl { get; set; }

        [JsonProperty("provider", NullValueHandling = NullValueHandling.Ignore)]
        public string Provider { get; set; }

        [JsonProperty("provider_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ProviderId { get; set; }

        [JsonProperty("provider_params", NullValueHandling = NullValueHandling.Ignore)]
        public List<ProviderParam> ProviderParams { get; set; }

        [JsonProperty("short_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortTitle { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public TypeEnum? ResultType { get; set; }

        [JsonProperty("video_attributes", NullValueHandling = NullValueHandling.Ignore)]
        public PosterAttributes VideoAttributes { get; set; }

        [JsonProperty("current_user_metadata", NullValueHandling = NullValueHandling.Ignore)]
        public CurrentUserMetadata CurrentUserMetadata { get; set; }

        [JsonProperty("published_at", NullValueHandling = NullValueHandling.Ignore)]
        public long? PublishedAt { get; set; }

        [JsonProperty("view_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? ViewCount { get; set; }

        [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
        public Author Author { get; set; }

        [JsonProperty("sponsorship", NullValueHandling = NullValueHandling.Ignore)]
        public Sponsorship Sponsorship { get; set; }

        [JsonProperty("article_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ArticleType { get; set; }

        [JsonProperty("draft", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Draft { get; set; }

        [JsonProperty("featured_slot")]
        public string FeaturedSlot { get; set; }

        [JsonProperty("for_homepage", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ForHomepage { get; set; }

        [JsonProperty("for_mobile", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ForMobile { get; set; }

        [JsonProperty("preview_image", NullValueHandling = NullValueHandling.Ignore)]
        public Uri PreviewImage { get; set; }

        [JsonProperty("sponsor_image")]
        public object SponsorImage { get; set; }

        [JsonProperty("sponsor_image_style", NullValueHandling = NullValueHandling.Ignore)]
        public SponsorImageStyle? SponsorImageStyle { get; set; }

        [JsonProperty("sponsor_link")]
        public string SponsorLink { get; set; }

        [JsonProperty("sponsor_phrase")]
        public string SponsorPhrase { get; set; }

        [JsonProperty("sponsored", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Sponsored { get; set; }

        [JsonProperty("votes_total", NullValueHandling = NullValueHandling.Ignore)]
        public long? VotesTotal { get; set; }

        [JsonProperty("about_me_summary", NullValueHandling = NullValueHandling.Ignore)]
        public string AboutMeSummary { get; set; }

        [JsonProperty("avatar", NullValueHandling = NullValueHandling.Ignore)]
        public Avatar Avatar { get; set; }

        [JsonProperty("human_readable_role_for_display")]
        public HumanReadableRoleForDisplay? HumanReadableRoleForDisplay { get; set; }

        [JsonProperty("iq", NullValueHandling = NullValueHandling.Ignore)]
        public long? Iq { get; set; }

        [JsonProperty("login", NullValueHandling = NullValueHandling.Ignore)]
        public string Login { get; set; }

        [JsonProperty("role_for_display")]
        public RoleForDisplay? RoleForDisplay { get; set; }
    }

    public partial class Artist
    {
        [JsonProperty("_type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("api_path")]
        public string ApiPath { get; set; }

        [JsonProperty("header_image_url")]
        public Uri HeaderImageUrl { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("index_character")]
        public string IndexCharacter { get; set; }

        [JsonProperty("is_meme_verified")]
        public bool IsMemeVerified { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("iq", NullValueHandling = NullValueHandling.Ignore)]
        public long? Iq { get; set; }
    }

    public partial class Author
    {
        [JsonProperty("_type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("about_me_summary")]
        public string AboutMeSummary { get; set; }

        [JsonProperty("api_path")]
        public string ApiPath { get; set; }

        [JsonProperty("avatar")]
        public Avatar Avatar { get; set; }

        [JsonProperty("header_image_url")]
        public Uri HeaderImageUrl { get; set; }

        [JsonProperty("human_readable_role_for_display")]
        public HumanReadableRoleForDisplay HumanReadableRoleForDisplay { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("iq")]
        public long Iq { get; set; }

        [JsonProperty("is_meme_verified")]
        public bool IsMemeVerified { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role_for_display")]
        public RoleForDisplay RoleForDisplay { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("current_user_metadata")]
        public CurrentUserMetadata CurrentUserMetadata { get; set; }
    }

    public partial class Avatar
    {
        [JsonProperty("tiny")]
        public Medium Tiny { get; set; }

        [JsonProperty("thumb")]
        public Medium Thumb { get; set; }

        [JsonProperty("small")]
        public Medium Small { get; set; }

        [JsonProperty("medium")]
        public Medium Medium { get; set; }
    }

    public partial class Medium
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("bounding_box")]
        public PosterAttributes BoundingBox { get; set; }
    }

    public partial class PosterAttributes
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }

    public partial class CurrentUserMetadata
    {
        [JsonProperty("permissions")]
        public List<object> Permissions { get; set; }

        [JsonProperty("excluded_permissions")]
        public List<ExcludedPermission> ExcludedPermissions { get; set; }

        [JsonProperty("interactions", NullValueHandling = NullValueHandling.Ignore)]
        public Interactions Interactions { get; set; }
    }

    public partial class Interactions
    {
        [JsonProperty("following")]
        public bool Following { get; set; }
    }

    public partial class DfpKv
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("values")]
        public List<string> Values { get; set; }
    }

    public partial class ProviderParam
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class ReleaseDateComponents
    {
        [JsonProperty("year")]
        public long Year { get; set; }

        [JsonProperty("month")]
        public long? Month { get; set; }

        [JsonProperty("day")]
        public long? Day { get; set; }
    }

    public partial class Sponsorship
    {
        [JsonProperty("_type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("api_path")]
        public string ApiPath { get; set; }

        [JsonProperty("sponsor_image")]
        public object SponsorImage { get; set; }

        [JsonProperty("sponsor_image_style")]
        public SponsorImageStyle SponsorImageStyle { get; set; }

        [JsonProperty("sponsor_link")]
        public string SponsorLink { get; set; }

        [JsonProperty("sponsor_phrase")]
        public object SponsorPhrase { get; set; }

        [JsonProperty("sponsored")]
        public bool Sponsored { get; set; }
    }

    public partial class Stats
    {
        [JsonProperty("unreviewed_annotations")]
        public long UnreviewedAnnotations { get; set; }

        [JsonProperty("hot")]
        public bool Hot { get; set; }

        [JsonProperty("pageviews")]
        public long Pageviews { get; set; }

        [JsonProperty("concurrents", NullValueHandling = NullValueHandling.Ignore)]
        public long? Concurrents { get; set; }
    }

    public enum TypeEnum { Album, Article, Artist, Lyric, Song, TopHit, User, Video };

    public enum ExcludedPermission { Follow, ViewRelevanceReason };

    public enum HumanReadableRoleForDisplay { Contributor, Editor, Staff };

    public enum RoleForDisplay { Contributor, Editor, Staff };

    public enum LyricsState { Complete };

    public enum SponsorImageStyle { Normal };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                ExcludedPermissionConverter.Singleton,
                HumanReadableRoleForDisplayConverter.Singleton,
                RoleForDisplayConverter.Singleton,
                LyricsStateConverter.Singleton,
                SponsorImageStyleConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "album":
                    return TypeEnum.Album;
                case "article":
                    return TypeEnum.Article;
                case "artist":
                    return TypeEnum.Artist;
                case "lyric":
                    return TypeEnum.Lyric;
                case "song":
                    return TypeEnum.Song;
                case "top_hit":
                    return TypeEnum.TopHit;
                case "user":
                    return TypeEnum.User;
                case "video":
                    return TypeEnum.Video;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Album:
                    serializer.Serialize(writer, "album");
                    return;
                case TypeEnum.Article:
                    serializer.Serialize(writer, "article");
                    return;
                case TypeEnum.Artist:
                    serializer.Serialize(writer, "artist");
                    return;
                case TypeEnum.Lyric:
                    serializer.Serialize(writer, "lyric");
                    return;
                case TypeEnum.Song:
                    serializer.Serialize(writer, "song");
                    return;
                case TypeEnum.TopHit:
                    serializer.Serialize(writer, "top_hit");
                    return;
                case TypeEnum.User:
                    serializer.Serialize(writer, "user");
                    return;
                case TypeEnum.Video:
                    serializer.Serialize(writer, "video");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class ExcludedPermissionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ExcludedPermission) || t == typeof(ExcludedPermission?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "follow":
                    return ExcludedPermission.Follow;
                case "view_relevance_reason":
                    return ExcludedPermission.ViewRelevanceReason;
            }
            throw new Exception("Cannot unmarshal type ExcludedPermission");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ExcludedPermission)untypedValue;
            switch (value)
            {
                case ExcludedPermission.Follow:
                    serializer.Serialize(writer, "follow");
                    return;
                case ExcludedPermission.ViewRelevanceReason:
                    serializer.Serialize(writer, "view_relevance_reason");
                    return;
            }
            throw new Exception("Cannot marshal type ExcludedPermission");
        }

        public static readonly ExcludedPermissionConverter Singleton = new ExcludedPermissionConverter();
    }

    internal class HumanReadableRoleForDisplayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(HumanReadableRoleForDisplay) || t == typeof(HumanReadableRoleForDisplay?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Contributor":
                    return HumanReadableRoleForDisplay.Contributor;
                case "Editor":
                    return HumanReadableRoleForDisplay.Editor;
                case "Staff":
                    return HumanReadableRoleForDisplay.Staff;
            }
            throw new Exception("Cannot unmarshal type HumanReadableRoleForDisplay");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (HumanReadableRoleForDisplay)untypedValue;
            switch (value)
            {
                case HumanReadableRoleForDisplay.Contributor:
                    serializer.Serialize(writer, "Contributor");
                    return;
                case HumanReadableRoleForDisplay.Editor:
                    serializer.Serialize(writer, "Editor");
                    return;
                case HumanReadableRoleForDisplay.Staff:
                    serializer.Serialize(writer, "Staff");
                    return;
            }
            throw new Exception("Cannot marshal type HumanReadableRoleForDisplay");
        }

        public static readonly HumanReadableRoleForDisplayConverter Singleton = new HumanReadableRoleForDisplayConverter();
    }

    internal class RoleForDisplayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(RoleForDisplay) || t == typeof(RoleForDisplay?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "contributor":
                    return RoleForDisplay.Contributor;
                case "editor":
                    return RoleForDisplay.Editor;
                case "staff":
                    return RoleForDisplay.Staff;
            }
            throw new Exception("Cannot unmarshal type RoleForDisplay");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (RoleForDisplay)untypedValue;
            switch (value)
            {
                case RoleForDisplay.Contributor:
                    serializer.Serialize(writer, "contributor");
                    return;
                case RoleForDisplay.Editor:
                    serializer.Serialize(writer, "editor");
                    return;
                case RoleForDisplay.Staff:
                    serializer.Serialize(writer, "staff");
                    return;
            }
            throw new Exception("Cannot marshal type RoleForDisplay");
        }

        public static readonly RoleForDisplayConverter Singleton = new RoleForDisplayConverter();
    }

    internal class LyricsStateConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LyricsState) || t == typeof(LyricsState?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "complete")
            {
                return LyricsState.Complete;
            }
            throw new Exception("Cannot unmarshal type LyricsState");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LyricsState)untypedValue;
            if (value == LyricsState.Complete)
            {
                serializer.Serialize(writer, "complete");
                return;
            }
            throw new Exception("Cannot marshal type LyricsState");
        }

        public static readonly LyricsStateConverter Singleton = new LyricsStateConverter();
    }

    internal class SponsorImageStyleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SponsorImageStyle) || t == typeof(SponsorImageStyle?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "normal")
            {
                return SponsorImageStyle.Normal;
            }
            throw new Exception("Cannot unmarshal type SponsorImageStyle");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SponsorImageStyle)untypedValue;
            if (value == SponsorImageStyle.Normal)
            {
                serializer.Serialize(writer, "normal");
                return;
            }
            throw new Exception("Cannot marshal type SponsorImageStyle");
        }

        public static readonly SponsorImageStyleConverter Singleton = new SponsorImageStyleConverter();
    }
}
