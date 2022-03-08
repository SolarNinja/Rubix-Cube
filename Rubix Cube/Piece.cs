using System;
using System.Collections.Generic;
using System.Text;

namespace Rubix_Cube
{
    public abstract class Piece
    {
        protected int numberOfFaces, rotation;
        protected string[] faceColours;
        protected int x, y, z;

        public Piece(int numberOfFaces)
        {
            this.numberOfFaces = numberOfFaces;
            faceColours = new string[numberOfFaces];
        }

        public abstract void AutoAssignColours(int cubeX, int cubeY, int cubeZ);
        public void ManualAssignColours(string[] passedInColours)
        {
            for (int i = 0; i < numberOfFaces; i++)
            {
                faceColours[i] = passedInColours[i];
            }
        }
    }

    // Each piece is created in a default orientation, then put into its correct position.
    // Standard cube orientation has white top and blue front.
    // A corner is created like the top-back-left piece, assigning the colours in the order.
    // An edge piece is created like the top-back-middle piece, assigning the colours top-back.
    // A centre piece is only a single colour, and hence does not have a colour assigning order.

    public class Corner : Piece
    {
        public Corner(int x, int y, int z, int rotation) : base(3)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.rotation = rotation;
        }

        public override void AutoAssignColours(int cubeX, int cubeY, int cubeZ)
        {
            string top;
            string back;
            string left;

            // I don't particularly like coding every case but I can only see it feasable that way.
            
            if (z == 0)
            {
                top = "white";
                if (x == y)
                {
                    if (x == 0)
                    {
                        back = "green";
                        left = "red";
                    }
                    else
                    {
                        back = "blue";
                        left = "orange";
                    }
                }
                else
                {
                    if (x == 0)
                    {
                        back = "red";
                        left = "blue";
                    }
                    else
                    {
                        back = "orange";
                        left = "green";
                    }
                }
            }
            else
            {
                top = "yellow";
                if (x == y)
                {
                    if (x == 0)
                    {
                        back = "red";
                        left = "green";
                    }
                    else
                    {
                        back = "orange";
                        left = "blue";
                    }
                }
                else
                {
                    if (x == 0)
                    {
                        back = "blue";
                        left = "red";
                    }
                    else
                    {
                        back = "green";
                        left = "orange";
                    }
                }
            }
            faceColours[0] = top;
            faceColours[1] = back;
            faceColours[2] = left;
        }
    }

    public class Edge : Piece
    {
        public Edge(int x, int y, int z, int rotation) : base(2)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.rotation = rotation;
        }

        public override void AutoAssignColours(int cubeX, int cubeY, int cubeZ)
        {
            string top;
            string back;

            if (y == 0)
            {
                back = "green";
                top = FrontAndBack();
            }
            else if (y != cubeY)
            {
                if (z == 0)
                {
                    top = "white";
                }
                else
                {
                    top = "yellow";
                }

                if (x == 0)
                {
                    back = "red";
                }
                else
                {
                    back = "orange";
                }
            }
            else
            {
                back = "blue";
                FrontAndBack();
            }

            faceColours[0] = top;
            faceColours[1] = back;

            string FrontAndBack()
            {
                if (z == 0)
                {
                    top = "white";
                }
                else if (z != cubeZ)
                {
                    if (cubeX == 0)
                    {
                        top = "red";
                    }
                    else
                    {
                        top = "orange";
                    }
                }
                else
                {
                    top = "yellow";
                }
                return top;
            }
        }
    }

    public class Centre : Piece
    {
        public Centre(int x, int y, int z, int rotation) : base(1)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.rotation = rotation;
        }

        public override void AutoAssignColours(int cubeX, int cubeY, int cubeZ)
        {
            string faceColour;
            if (x == 0)
            {
                faceColour = "green";
            }
            else if (x == cubeX)
            {
                faceColour = "blue";
            }    
            else if (y == 0)
            {
                faceColour = "red";
            }
            else if (y == cubeY)
            {
                faceColour = "orange";
            }
            else if (z == 0)
            {
                faceColour = "white";
            }
            else
            {
                faceColour = "yellow";
            }
            faceColours[0] = faceColour;
        }
    }
}
