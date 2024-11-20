using HeinekenRobot.Models;
using HeinekenRobot.Repository.LocationFolder;

namespace HeinekenRobot.Service.LocationFolder
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repository;

        public LocationService(ILocationRepository repository)
        {
            _repository = repository;
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

        public async Task updateLocation(Location location)
        {
            var check = await _repository.GetLocationByIdAsync(location.LocationId);
            if (check == null)
            {
                throw new KeyNotFoundException("Location not found.");
            }



            // Cập nhật các thuộc tính
            check.Name = location.Name;
            check.RegionId = location.RegionId;
            check.Latitude = location.Latitude;
            check.Longitude = location.Longitude;


            await _repository.updateLocation(check);
        }

        public async Task DeleteLocation(int locationId)
        {
            var location = await _repository.GetLocationByIdAsync(locationId);
            if (location == null)
            {
                throw new KeyNotFoundException("Location not found.");
            }

            if (await _repository.IsLocationOperated(locationId))
            {
                throw new InvalidOperationException("Cannot delete a location that has been operated.");

            }
            await _repository.DeleteLocation(locationId);
        }

    }
}
