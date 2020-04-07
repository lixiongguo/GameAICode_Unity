using System;


public class Utils
{
    public static float RandomClamped()
    {
        return UnityEngine.Random.Range(-1, 1);

    }
}
public class Params
{

    public static int iFramesPerSecond = 60;


    //-------------------------------------used for the neural network
    public static int iNumInputs = 1;
    public static int iNumHidden = 1;//一个中间层就够了
    public static int iNeuronsPerHiddenLayer = 10;
    public static int iNumOutputs = 2;//左右两边的轨道值

    //for tweeking the sigmoid function
    public static float dActivationResponse = 1;
    //bias value
    public static float dBias = -1;

    //--------------------------------------used to define the sweepers
    //lgx 这个限制的开放作为下次训练的一个目标
    ////limits how fast the sweepers can turn
    //public static float dMaxTurnRate;

    //public static float dMaxSpeed;



    //--------------------------------------controller parameters
    public static int iNumTourneyCompetitors;
    public static int iNumOnScreen;
    public static int dPercentageBestToSelectFrom;

    public static int iNumMines = 40;

    //number of time steps we allow for each generation to live
    //平均控制60帧一秒就是30多秒
    public static int iNumTicks = 2000;

    //scaling factor for mines
    public static float collisionRadius = 0.5f;

    //---------------------------------------GA parameters
    public static float dCrossoverRate = 0.7f;
    public static float dMutationRate = 0.1f;

    //the maximum amount the ga may mutate each weight by
    public static float dMaxPerturbation = 0.3f;

    //used for elitism
    public static int iNumElite = 4;
    public static int iNumCopiesElite = 1;

    public static float MaxX = 9.5f;
    public static float MinX = -9.6f;
    public static float MaxY = 6.3f;
    public static float MinY = -4.5f;

    public static float mineSweeperSpeedPerFrame = 0.05f;
    void LoadInParameters(string fileName)
    {

    }
};
