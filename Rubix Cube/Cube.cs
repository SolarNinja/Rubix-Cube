using System;
using System.Collections.Generic;
using System.Text;

namespace Rubix_Cube
{
    public class Cube
    {
        int cubeX, cubeY, cubeZ;
        Piece[,,] cubePieces;

        public Cube(int cubeX, int cubeY, int cubeZ)
        {
            this.cubeX = cubeX;
            this.cubeY = cubeY;
            this.cubeZ = cubeZ;
            cubePieces = new Piece[cubeX, cubeY, cubeZ];
        }

        public void AssembleCube()
        {
            for (int x = 0; x < cubeX; x++)
            {
                for (int y = 0; y < cubeY; y++)
                {
                    for (int z = 0; z < cubeZ; z++)
                    {
                        // If all coordinates are extremes, it must be a corner.
                        if ((x == 0 || x == cubeX - 1) && (y == 0 || y == cubeY - 1) && (z == 0 || z == cubeZ - 1))
                        {
                            // It's rotation is relative to its correct rotation. Each additional 1 to the rotation means another twist of the corner piece.
                            cubePieces[x, y, z] = new Corner(x, y, z, 0);
                        }
                        if (x != 0 && x != cubeX - 1 && y != 0 && y != cubeY - 1 && z != 0 && z != cubeZ - 1)
                        {
                            cubePieces[x, y, z] = new Centre(x, y, z, 0);
                        }
                        else
                        {
                            cubePieces[x, y, z] = new Edge(x, y, z, 0);
                        }
                    }
                }
            }
        }

        public void Turn(char layerDirection, int layerNumber)
        {
            Piece[,] subArray = null;
            /*
             * u = z 0
             * e = z 1
             * d = z cubeZ
             * -----
             * z n = z n
             * 
             * l = x 0
             * m = x 1
             * r = x cubeX
             * -----
             * x n = x n
             * 
             * b = y 0
             * s = y 1
             * f = y cubeY
             * -----
             * y n = y n
             */

            switch (layerDirection)
            {
                case 'x':
                    cubePieces
                    break;

                case 'y':
                    break;

                case 'z':
                    break;
            }
        }
    }
}
