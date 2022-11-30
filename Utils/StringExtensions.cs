namespace Utils;


public static class StringExtensions
{
  /// <summary>
  /// snake_to_upper_camel -> SnakeToUpperCamel
  /// </summary>
  /// <param name="self"></param>
  /// <returns></returns>
  public static string SnakeToUpperCamel(this string self)
  {
    if (string.IsNullOrEmpty(self)) return self;

    return self
      .Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
      .Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1))
      .Aggregate(string.Empty, (s1, s2) => s1 + s2);
  }

  /// <summary>
  /// snake_to_upper_camel -> snakeToUpperCamel
  /// </summary>
  public static string SnakeToLowerCamel(this string self)
  {
    if (string.IsNullOrEmpty(self)) return self;

    return self
      .SnakeToUpperCamel()
      .Insert(0, char.ToLowerInvariant(self[0]).ToString()).Remove(1, 1);
  }

  /// <summary>
  /// snakeToUpperCamel -> SnakeToUpperCamel
  /// </summary>
  /// <param name="self"></param>
  /// <returns></returns>
  public static string ToUpperCamel(this string self)
  {
    return self.Insert(0, char.ToUpperInvariant(self[0]).ToString()).Remove(1, 1);
  }

  /// <summary>
  /// SnakeToUpperCamel -> snakeToUpperCamel
  /// </summary>
  /// <param name="self"></param>
  /// <returns></returns>
  public static string ToLowerCamel(this string self)
  {
    return self.Insert(0, char.ToLowerInvariant(self[0]).ToString()).Remove(1, 1);
  }

  /// <summary>
  /// 大文字チェック
  /// </summary>
  /// <param name="ch"></param>
  /// <returns></returns>
  static bool UpperCheck(char ch) => 'A' <= ch && ch <= 'Z';

  /// <summary>
  /// SnakeToUpperCamel -> snake_to_upper_camel
  /// </summary>
  /// <param name="self"></param>
  /// <returns></returns>
  public static string ToSnake(this string self)
  {
    return  string.Join("", self.ToLowerCamel().Select(_ => UpperCheck(_) ? $"_{char.ToLowerInvariant(_)}" : $"{_}"));
  }
}