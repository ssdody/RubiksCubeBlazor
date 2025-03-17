using WebApplicationAPI.Constants;
using WebApplicationAPI.Interfaces;

namespace WebApplicationAPI.Models
{
    public class RubiksCube: IRubiksCube
    {
        private string[][] cube = new string[6][] {
            new string[9] { "G", "G", "G", "G", "G", "G", "G", "G", "G" }, // Front (Green)
            new string[9] { "R", "R", "R", "R", "R", "R", "R", "R", "R" }, // Right (Red)
            new string[9] { "W", "W", "W", "W", "W", "W", "W", "W", "W" }, // Up (White)
            new string[9] { "B", "B", "B", "B", "B", "B", "B", "B", "B" }, // Back (Blue)
            new string[9] { "O", "O", "O", "O", "O", "O", "O", "O", "O" }, // Left (Orange)
            new string[9] { "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y" }  // Down (Yellow)
        };

        public Dictionary<string, string[]> GetCubeState()
        {
            return new Dictionary<string, string[]>
                    {
                        { "Front", cube[0] },
                        { "Right", cube[1] },
                        { "Up", cube[2] },
                        { "Back", cube[3] },
                        { "Left", cube[4] },
                        { "Down", cube[5] }
                    };
        }

        public void RotateFaceClockwise(RubikCubeFaceEnum face)
        {
            RotateFace(face, true);
            RotateAdjacentSides(face, true);
        }

        public void RotateFaceAntiClockwise(RubikCubeFaceEnum face)
        {
            RotateFace(face, false);
            RotateAdjacentSides(face, false);
        }

        private void RotateFace(RubikCubeFaceEnum face, bool clockwise)
        {
            var temp = (string[])cube[(int)face].Clone();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (clockwise)
                    {
                        cube[(int)face][j * 3 + i] = temp[(2 - i) * 3 + j];
                    }
                    else
                    {
                        cube[(int)face][i * 3 + j] = temp[(2 - j) * 3 + (2 - i)];
                    }
                }
            }
        }

        private void RotateAdjacentSides(RubikCubeFaceEnum face, bool clockwise)
        {
            var temp = new string[3];

            switch (face)
            {
                case RubikCubeFaceEnum.Front:
                    Array.Copy(cube[2], 6, temp, 0, 3);
                    if (clockwise)
                    {
                        Array.Copy(cube[4], 0, cube[2], 6, 3); // Left to Up
                        Array.Copy(cube[5], 0, cube[4], 0, 3); // Down to Left
                        Array.Copy(cube[1], 0, cube[5], 0, 3); // Right to Down
                        Array.Copy(temp, 0, cube[1], 0, 3);   // Top to Right
                    }
                    else
                    {
                        Array.Copy(cube[1], 0, cube[2], 6, 3); // Right to Up
                        Array.Copy(cube[5], 0, cube[1], 0, 3); // Down to Right
                        Array.Copy(cube[4], 0, cube[5], 0, 3); // Left to Down
                        Array.Copy(temp, 0, cube[4], 0, 3);   // Top to Left
                    }
                    break;

                case RubikCubeFaceEnum.Right:
                    Array.Copy(cube[2], 2, temp, 0, 3);
                    if (clockwise)
                    {
                        Array.Copy(cube[0], 2, cube[2], 2, 3); // Front to Up
                        Array.Copy(cube[5], 2, cube[0], 2, 3); // Down to Front
                        Array.Copy(cube[3], 6, cube[5], 2, 3); // Back to Down
                        Array.Copy(temp, 0, cube[3], 6, 3);    // Up to Back
                    }
                    else
                    {
                        Array.Copy(cube[3], 6, cube[2], 2, 3); // Back to Up
                        Array.Copy(cube[5], 2, cube[3], 6, 3); // Down to Back
                        Array.Copy(cube[0], 2, cube[5], 2, 3); // Front to Down
                        Array.Copy(temp, 0, cube[0], 2, 3);    // Up to Front
                    }
                    break;

                case RubikCubeFaceEnum.Up:
                    Array.Copy(cube[0], 0, temp, 0, 3);
                    if (clockwise)
                    {
                        Array.Copy(cube[4], 0, cube[0], 0, 3); // Left to Front
                        Array.Copy(cube[3], 0, cube[4], 0, 3); // Back to Left
                        Array.Copy(cube[1], 0, cube[3], 0, 3); // Right to Back
                        Array.Copy(temp, 0, cube[1], 0, 3);    // Front to Right
                    }
                    else
                    {
                        Array.Copy(cube[1], 0, cube[0], 0, 3); // Right to Front
                        Array.Copy(cube[3], 0, cube[1], 0, 3); // Back to Right
                        Array.Copy(cube[4], 0, cube[3], 0, 3); // Left to Back
                        Array.Copy(temp, 0, cube[4], 0, 3);    // Front to Left
                    }
                    break;

                case RubikCubeFaceEnum.Down:
                    Array.Copy(cube[0], 6, temp, 0, 3);
                    if (clockwise)
                    {
                        Array.Copy(cube[1], 6, cube[0], 6, 3); // Right to Front
                        Array.Copy(cube[3], 6, cube[1], 6, 3); // Back to Right
                        Array.Copy(cube[4], 6, cube[3], 6, 3); // Left to Back
                        Array.Copy(temp, 0, cube[4], 6, 3);    // Front to Left
                    }
                    else
                    {
                        Array.Copy(cube[4], 6, cube[0], 6, 3); // Left to Front
                        Array.Copy(cube[3], 6, cube[4], 6, 3); // Back to Left
                        Array.Copy(cube[1], 6, cube[3], 6, 3); // Right to Back
                        Array.Copy(temp, 0, cube[1], 6, 3);    // Front to Right
                    }
                    break;

                case RubikCubeFaceEnum.Left:
                    Array.Copy(cube[2], 0, temp, 0, 3);
                    if (clockwise)
                    {
                        Array.Copy(cube[0], 0, cube[2], 0, 3); // Front to Up
                        Array.Copy(cube[5], 0, cube[0], 0, 3); // Down to Front
                        Array.Copy(cube[3], 2, cube[5], 0, 3); // Back to Down
                        Array.Copy(temp, 0, cube[3], 2, 3);    // Up to Back
                    }
                    else
                    {
                        Array.Copy(cube[3], 2, cube[2], 0, 3); // Back to Up
                        Array.Copy(cube[5], 0, cube[3], 2, 3); // Down to Back
                        Array.Copy(cube[0], 0, cube[5], 0, 3); // Front to Down
                        Array.Copy(temp, 0, cube[0], 0, 3);    // Up to Front
                    }
                    break;

                case RubikCubeFaceEnum.Back:
                    Array.Copy(cube[2], 6, temp, 0, 3);
                    if (clockwise)
                    {
                        Array.Copy(cube[4], 6, cube[2], 6, 3); // Left to Up
                        Array.Copy(cube[5], 6, cube[4], 6, 3); // Down to Left
                        Array.Copy(cube[1], 6, cube[5], 6, 3); // Right to Down
                        Array.Copy(temp, 0, cube[1], 6, 3);   // Top to Right
                    }
                    else
                    {
                        Array.Copy(cube[1], 6, cube[2], 6, 3); // Right to Up
                        Array.Copy(cube[5], 6, cube[1], 6, 3); // Down to Right
                        Array.Copy(cube[4], 6, cube[5], 6, 3); // Left to Down
                        Array.Copy(temp, 0, cube[4], 6, 3);    // Top to Left
                    }
                    break;
            }
        }
    }
}