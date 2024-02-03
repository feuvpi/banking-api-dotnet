using Docker.DotNet;
using Docker.DotNet.Models;

namespace Service.Utils
{
    public class DockerManager
    {
        private const string DBContainer = "/banking-api-dotnet-postgres-1";

        private readonly DockerClient _dockerClient;

        public DockerManager()
        {
            _dockerClient = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();
        }

        public async Task StartDatabase()
        {
            await _dockerClient.Containers.StartContainerAsync(DBContainer, new ContainerStartParameters());
            Console.WriteLine("PostgreSQL database container started.");
        }

        public async Task StopDatabase()
        {
            await _dockerClient.Containers.StopContainerAsync(DBContainer, new ContainerStopParameters());
            Console.WriteLine("PostgreSQL database container stopped.");
        }

        public async Task<bool> IsDatabaseContainerRunning()
        {
            try
            {
                // -- Get a list of all containers
                var containers = await _dockerClient.Containers.ListContainersAsync(
                    new ContainersListParameters { All = true });
                // -- Check if the database container is among the running containers
                return containers.Any(container => container.Names.Contains("/banking-api-dotnet-postgres-1") &&
                container.State == "running");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if database container is running: {ex.Message}");
                return false; 
            }
        }
    }
}
