namespace WanaKanaShaapu
{
    public static class TreeConstants
    {
        readonly public static Dictionary<string, Node> KanaToHepburnTree = TreeBuilder.BuildKanaToHepburnTree();
        readonly public static Dictionary<string, Node> RomajiToKanaTree = TreeBuilder.BuildRomajiToKanaTree();
    }
}