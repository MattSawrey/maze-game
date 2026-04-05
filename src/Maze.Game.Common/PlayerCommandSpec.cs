using System;

namespace Maze.Game.Common
{
    /// <summary>
    /// Describes a player command: canonical name (used after input is normalized), optional usage suffix for the help text, and an optional short alias.
    /// </summary>
    public sealed class PlayerCommandSpec
    {
        public PlayerCommandSpec(string canonicalName, string usageSuffix = "", string shortAlias = "")
        {
            CanonicalName = canonicalName ?? throw new ArgumentNullException(nameof(canonicalName));
            UsageSuffix = usageSuffix ?? "";
            ShortAlias = shortAlias ?? "";
        }

        public string CanonicalName { get; }

        /// <summary>Extra text after the canonical name in the help line, e.g. <c> {n, s, e, w}</c>.</summary>
        public string UsageSuffix { get; }

        public string ShortAlias { get; }

        /// <summary>Single help line without leading bullet.</summary>
        public string DisplayText
        {
            get
            {
                var full = CanonicalName + UsageSuffix;
                return string.IsNullOrEmpty(ShortAlias)
                    ? full
                    : $"{full} ({ShortAlias})";
            }
        }
    }
}
