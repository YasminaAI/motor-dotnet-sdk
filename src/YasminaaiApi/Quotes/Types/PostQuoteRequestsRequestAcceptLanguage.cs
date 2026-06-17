using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

[JsonConverter(
    typeof(PostQuoteRequestsRequestAcceptLanguage.PostQuoteRequestsRequestAcceptLanguageSerializer)
)]
[Serializable]
public readonly record struct PostQuoteRequestsRequestAcceptLanguage : IStringEnum
{
    public static readonly PostQuoteRequestsRequestAcceptLanguage Ar = new(Values.Ar);

    public PostQuoteRequestsRequestAcceptLanguage(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static PostQuoteRequestsRequestAcceptLanguage FromCustom(string value)
    {
        return new PostQuoteRequestsRequestAcceptLanguage(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(PostQuoteRequestsRequestAcceptLanguage value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PostQuoteRequestsRequestAcceptLanguage value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PostQuoteRequestsRequestAcceptLanguage value) =>
        value.Value;

    public static explicit operator PostQuoteRequestsRequestAcceptLanguage(string value) =>
        new(value);

    internal class PostQuoteRequestsRequestAcceptLanguageSerializer
        : JsonConverter<PostQuoteRequestsRequestAcceptLanguage>
    {
        public override PostQuoteRequestsRequestAcceptLanguage Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new PostQuoteRequestsRequestAcceptLanguage(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PostQuoteRequestsRequestAcceptLanguage value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PostQuoteRequestsRequestAcceptLanguage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new PostQuoteRequestsRequestAcceptLanguage(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PostQuoteRequestsRequestAcceptLanguage value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Ar = "ar";
    }
}
