namespace ControlMaterials.Total.Count.Highlighting
{
    public class HighlightOn
    {
        public IHighlighting Item { get; set; }

        public void ChangeHighlight(uint head)
        {
            if (head > Item.Sum)
            {
                Item.SetColor(Item.Violation);
            }
            else if (head == Item.Sum)
            {
                Item.SetColor(Item.Conformity);
            }
        }

        public static void Recalculate() { }
    }
}
