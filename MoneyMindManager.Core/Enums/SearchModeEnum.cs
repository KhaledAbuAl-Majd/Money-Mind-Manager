namespace MoneyMindManager.Core.Enums
{
    public enum enTextSearchMode
    {
        /// <summary>
        /// search with (full text search Using "Contains" OR LIKE text %) - faster
        /// </summary>
        WordsPrefix_Fast = 1,

        /// <summary>
        /// search using Like Statement - any part of text "Like" - slower
        /// </summary>
        Substring_Slow = 2
    }
}
