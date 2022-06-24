namespace Uwp.SQLite.Model
{
    public class TopicModel
    {
        public int TopicModelId { get; set; }
        public string Name { get; set; }
        public string Defination { get; set; }
        public byte[] Image { get; set; }
        public bool hasItem { get; set; }
        public bool isFavorite { get; set; }

        public int StudyModelId { get; set; }
        public StudyModel StudyModel { get; set; }
    }
}
