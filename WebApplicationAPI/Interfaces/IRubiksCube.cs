using WebApplicationAPI.Constants;

namespace WebApplicationAPI.Interfaces
{
    public interface IRubiksCube
    {
        Dictionary<string, string[]> GetCubeState();

        void RotateFaceClockwise(RubikCubeFaceEnum face);

        void RotateFaceAntiClockwise(RubikCubeFaceEnum face);
    }
}
