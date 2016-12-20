
namespace Business.Models
{
    public class MapMark
    {
        public LatLng LatLng { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
    }

    public class LatLng
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
