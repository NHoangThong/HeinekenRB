using HeinekenRobot.Models;
using HeinekenRobot.Repository;

namespace HeinekenRobot.Service
{
    public class LocationService:ILocationService
    {
        private readonly ILocationRepository _repository;

        public LocationService(ILocationRepository repository) {
            _repository= repository;
        }
        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            var locations = await _repository.GetAllLocations();

            return locations;
           
        }
        public async Task<bool> AddLocation(Location location)
        {
            // Kiểm tra tọa độ có hợp lệ không
            if (location.Latitude < -90 || location.Latitude > 90 || location.Longitude < -180 || location.Longitude > 180)
            {
                throw new Exception("Invalid coordinates.");
            }

            // Gọi repository để thêm địa điểm
            return await _repository.AddLocation(location);
        }
        public async Task<object?> GetLocationDetailsAsync(int locationId)
        {
            var location = await _repository.GetLocationByIdAsync(locationId);
            if (location == null)
            {
                return null; // Không tìm thấy địa điểm
            }

            // Tạo một đối tượng chứa thông tin cần thiết để trả về
            var locationDetails = new
            {
                location.LocationId,
                location.Name,
                Region = location.Region?.RegionName,
                location.Latitude,
                location.Longitude,
                Devices = location.Robots.Select(r => new
                {
                    DeviceName = r.RobotName,
                    DeviceType = "Robot",
                   
                    ConnectionStatus = r.Status

                }).Union(
                    location.RecycleMachines.Select(m => new
                    {
                        DeviceName = m.MachineId,
                        DeviceType = "Recycle Machine",
                     
                        ConnectionStatus = m.Status
                    })
                )
            };

            return locationDetails;
        }
    }
}
