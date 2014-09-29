using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Kinect;
using System.Linq;
using SocketIOClient;
using System.Collections;
using System.Diagnostics;

namespace KinectSkeletonApplication2
{
    public partial class MainWindow : Window
    {
        public static bool screenFacingAway = false;
        public static int xcal;
        public static int batWidth = 80;
        public static int batHeight = 20;
        public static int batPadding;
        //ingame Höhe ist real life Breite und umgekehrt
        public static int gameFieldHeight;
        public static int gameFieldWidth;
        public static int abstandToCanvas = 450;
        public static int canvasBLX = -160;
        public static int canvasBLY = -32;
        public static int canvasTRX = 150;
        public static int canvasTRY = 180;
        public static int kinectY = 0;
        public static double leftKTop;
        public static double leftKBot;
        public static double rightKTop;
        public static double rightKBot;
        public static double leftKRKPos;
        public static double rightKRKPos;
        public static double leftKRKPosX;
        public static double rightKRKPosX;
        public static bool calibrated = false;
        public static double ballPosXSave = 1;
        public static double ballPosYSave = 1;
        public static double movXSave = 1;
        public static double movYSave = 1;
        public static double canvasFactorX;
        public static double canvasFactorY;
        public static double ballPosX;
        public static double ballPosY;
        public static double bat1PosXTop;
        public static double bat1PosYTop;
        public static double bat1PosXBot;
        public static double bat1PosY;
        public static double bat2PosXBot;
        public static double bat2PosY;
        public static double bat2PosXTop;
        public static double bat2PosYTop;
        public static bool onePlayer = false;

        public BitmapSource source1;
        public BitmapSource source2;

        public static double xSave = 1;
        public static double ySave = 1;
        public static double zSave = 1;

        public static double maxDistance = 55;

        public static CallibrationPopUp callibrator;
        public static KinectSensor sensor1 = KinectSensor.KinectSensors[0];
        public static KinectSensor sensor2 = KinectSensor.KinectSensors[1];//KinectSensor.KinectSensors[1];
        public static Skeleton[] skeletonData1;
        public static Skeleton[] skeletonData2;
        public static double movY = 3.7;
        public static double movX = 2.5;
        public static double speed;
        public static String iP = "http://localhost:3000";
        public static Client socket;

        //bool dataSendOverThreshold = false;
        double[] betas = new double[3];
        public static int mode = 1;


        public static int pointsL = 0;
        public static int pointsR = 0;

        public static long lastFrameTime = 0;
        public static Stopwatch timer = null;
        public static double batHalfLength = 6;

        public MainWindow()
        {
            //canvasFactor = (int)(800 / Math.Abs(canvasBLX - canvasTRX));
            canvasFactorX = 640 / Math.Abs(canvasBLX - canvasTRX);
            canvasFactorY = 480 / Math.Abs(canvasBLY - canvasTRY);
            movY = 0.7;
            movX = 0.2;
            gameFieldHeight = Math.Abs(canvasBLY - canvasTRY);
            gameFieldWidth = Math.Abs(canvasTRX - canvasBLX);
            batPadding = gameFieldWidth/4;
            ballPosY = gameFieldWidth / 2;
            ballPosX = gameFieldHeight / 2;
            bat1PosYTop = 0;
            bat1PosY = 0;
            bat1PosXBot = batPadding;
            bat1PosXTop = batPadding;
            bat2PosYTop = 0;
            bat2PosY = 0;
            bat2PosXBot = gameFieldWidth - batPadding;
            bat2PosXTop = gameFieldWidth - batPadding;
            //speedX = movY;
            speed = gameFieldWidth*30;

            InitializeComponent();
            callibrator = new CallibrationPopUp();
            callibrator.Closed += callibrateField; 

            pongCanvas.Width = gameFieldWidth * canvasFactorX;
            pongCanvas.Height = gameFieldHeight * canvasFactorY;
            pongWindow.Width = gameFieldWidth * canvasFactorX*1.2;
            pongWindow.Height = gameFieldHeight * canvasFactorY*1.2;
            Canvas.SetLeft(bat1, (bat1PosXBot * canvasFactorX - maxDistance));
            Canvas.SetLeft(bat2, (bat2PosXBot * canvasFactorX - maxDistance));


            modeBox.Items.Add("Pong");
            modeBox.Items.Add("Head-Aim");

            //use HTTP
            socket = new Client(iP);
            System.Net.WebRequest.DefaultWebProxy = null;
            socket.Opened += websocket_Opened;
            socket.Error += websocket_Error;
            socket.SocketConnectionClosed += websocket_Closed;
            socket.Message += socketMessage;
            socket.Connect();


            socket.On("pong", (data) =>
            {
                int msg = Convert.ToInt32(data.Json.Args[0].ToString());
                if (msg == 1 || msg == 2)
                {
                    MainWindow.leftKTop = 76.031899452209473;
                    MainWindow.leftKBot = -100.20858895778656;
                    MainWindow.rightKTop = 92.502868175506592;
                    MainWindow.rightKBot = -92.35070281010121107;
                    MainWindow.canvasTRX = 100;
                    MainWindow.canvasTRY = 200;
                    MainWindow.canvasBLX = -150;
                    MainWindow.canvasBLY = -140;
                    MainWindow.calibrated = true;
                    //MainWindow.sensor1.ElevationAngle = 20;
                    //MainWindow.sensor2.ElevationAngle = 20;
                    MainWindow.gameFieldWidth = Math.Abs(MainWindow.canvasTRX - MainWindow.canvasBLX);
                    MainWindow.batPadding = gameFieldWidth / 4;

                    MainWindow.canvasBLX -= MainWindow.batPadding;
                    MainWindow.canvasTRX += MainWindow.batPadding;
                    MainWindow.gameFieldWidth = Math.Abs(MainWindow.canvasTRX - MainWindow.canvasBLX);

                    //canvasFactor = (int)(Math.Abs(canvasBLX - canvasTRX)/100);
                    MainWindow.canvasFactorX = 640 / Math.Abs(MainWindow.canvasBLX - MainWindow.canvasTRX);
                    MainWindow.canvasFactorY = 480 / Math.Abs(MainWindow.canvasBLY - MainWindow.canvasTRY);
                    MainWindow.movY = 4 / MainWindow.canvasFactorY;
                    MainWindow.movX = 4 / MainWindow.canvasFactorX;
                    MainWindow.gameFieldHeight = Math.Abs(canvasBLY - canvasTRY);
                    //canvasWidth = (int)(canvasWidth + canvasPaddingLeft * canvasFactorX);
                    MainWindow.maxDistance = MainWindow.gameFieldHeight / 6;
                    MainWindow.ballPosX = MainWindow.gameFieldWidth / 2;
                    MainWindow.ballPosY = MainWindow.gameFieldHeight / 2;
                    MainWindow.bat1PosYTop = 0;
                    MainWindow.bat1PosY = 0;
                    MainWindow.bat1PosXBot = MainWindow.batPadding;
                    MainWindow.bat1PosXTop = MainWindow.batPadding;
                    MainWindow.bat2PosYTop = 0;
                    MainWindow.bat2PosY = 0;
                    MainWindow.bat2PosXBot = MainWindow.gameFieldWidth - MainWindow.batPadding;
                    MainWindow.bat2PosXTop = MainWindow.gameFieldWidth - MainWindow.batPadding;
                    if (onePlayer)
                    {
                        MainWindow.bat2PosXBot = 2 * MainWindow.gameFieldWidth;
                        MainWindow.bat2PosXTop = 2 * MainWindow.gameFieldWidth;
                    }
                    MainWindow.speed = MainWindow.gameFieldWidth/3 ;/*
                    pongCanvas.Width = gameFieldWidth * canvasFactorX;
                    pongCanvas.Height = gameFieldHeight * canvasFactorY;
                    pongWindow.Width = gameFieldWidth * canvasFactorX * 1.2;
                    pongWindow.Height = gameFieldHeight * canvasFactorY * 1.2;*/

                    MainWindow.batWidth = MainWindow.gameFieldWidth / 20;



                    MainWindow.batHalfLength = MainWindow.gameFieldHeight / 4.5;
                    //Canvas.SetLeft(bat1, (bat1PosXBot * canvasFactorX - maxDistance));
                    //Canvas.SetLeft(bat2, (bat2PosXBot * canvasFactorX - maxDistance));
                    //callibrator = new CallibrationPopUp();
                    MainWindow.mode = 0;
                }
                if (msg == 0)
                {
                    MainWindow.mode = 1;
                }
                    
            });

            betas[0] = 200;
            betas[1] = 200;
            betas[2] = 200;

            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            this.Unloaded += new RoutedEventHandler(MainWindow_Unloaded);


            sensor1.SkeletonStream.Enable();
            sensor2.SkeletonStream.Enable();
            sensor1.ColorStream.Enable();
            sensor2.ColorStream.Enable();

            skeletonData1 = new Skeleton[sensor1.SkeletonStream.FrameSkeletonArrayLength];
            skeletonData2 = new Skeleton[sensor2.SkeletonStream.FrameSkeletonArrayLength];

            timer = new Stopwatch();
            timer.Start();
            lastFrameTime = timer.ElapsedMilliseconds;

            CompositionTarget.Rendering += gameLoop;
            
        }

        public void update( float deltaTime ) {
            setBallPos(deltaTime);
        }

        public void render(float deltaTime)
        {
            Canvas.SetTop(bat1, (gameFieldHeight - bat1PosY - batHalfLength) * canvasFactorY);
            Canvas.SetLeft(bat1, batPadding * canvasFactorX);
            bat1.Width = batWidth * canvasFactorX;
            bat1.Height = batHalfLength * 2 * canvasFactorY;

            Canvas.SetTop(bat2, (gameFieldHeight - bat2PosY - batHalfLength) * canvasFactorY);
            Canvas.SetLeft(bat2, (gameFieldWidth - batPadding - batWidth) * canvasFactorX);
            bat2.Width = batWidth * canvasFactorX;
            bat2.Height = batHalfLength * 2 * canvasFactorY;

            Canvas.SetLeft(ball, (ballPosX) * canvasFactorX);
            Canvas.SetTop(ball, (gameFieldHeight - ballPosY) * canvasFactorY);
        }

        void gameLoop(object sender, object e)
        {
            
            long currTime = timer.ElapsedMilliseconds;
            float deltaTime = (currTime - lastFrameTime) / 1000.0f;
            if (calibrated && mode == 0)
            {
                update(deltaTime);
                render(deltaTime);
            }
            lastFrameTime = currTime;
            if (Double.IsNaN(ballPosX) || Double.IsNaN(ballPosY))
            {
                ballPosY = ballPosYSave;
                ballPosX = ballPosXSave;
            }
            else
            {
                ballPosXSave = ballPosX;
                ballPosYSave = ballPosY;
            }
            if (Double.IsNaN(movX) || Double.IsNaN(movY))
            {
                movX = speed * deltaTime;
                movY = speed * deltaTime;
            }

        }

        public void callibrateField(object sender, EventArgs e)
        {
            
            /*
            canvasBLX -= (int)(canvasBLX * 0.35);
            canvasTRX -= (int)(canvasTRX * 0.35);
            canvasBLY += (int)(canvasBLY * 0.35);
            canvasTRY += (int)(canvasTRY * 0.35);
            */
            

            gameFieldWidth = Math.Abs(canvasTRX - canvasBLX);
            batPadding = gameFieldWidth / 4;

            canvasBLX -= batPadding;
            canvasTRX += batPadding;
            gameFieldWidth = Math.Abs(canvasTRX - canvasBLX);

            //canvasFactor = (int)(Math.Abs(canvasBLX - canvasTRX)/100);
            canvasFactorX = 640 / Math.Abs(canvasBLX - canvasTRX);
            canvasFactorY = 480 / Math.Abs(canvasBLY - canvasTRY);
            movY =  4 /canvasFactorY;
            movX = 4 / canvasFactorX;
            gameFieldHeight = Math.Abs(canvasBLY - canvasTRY);
            //canvasWidth = (int)(canvasWidth + canvasPaddingLeft * canvasFactorX);
            maxDistance = gameFieldHeight / 6;
            ballPosX = gameFieldWidth / 2;
            ballPosY = gameFieldHeight / 2;
            bat1PosYTop = 0;
            bat1PosY = 0;
            bat1PosXBot = batPadding;
            bat1PosXTop = batPadding;
            bat2PosYTop = 0;
            bat2PosY = 0;
            bat2PosXBot = gameFieldWidth - batPadding;
            bat2PosXTop = gameFieldWidth - batPadding;
            if (onePlayer)
            {
                bat2PosXBot = 2 * gameFieldWidth;
                bat2PosXTop = 2 * gameFieldWidth;
            }
            speed = gameFieldWidth / 10;
            pongCanvas.Width = gameFieldWidth * canvasFactorX;
            pongCanvas.Height = gameFieldHeight * canvasFactorY;
            pongWindow.Width = gameFieldWidth * canvasFactorX * 1.2;
            pongWindow.Height = gameFieldHeight * canvasFactorY * 1.2;

            batWidth = gameFieldWidth / 20;
            
            

            batHalfLength = gameFieldHeight / 4.5;
            Canvas.SetLeft(bat1, (bat1PosXBot * canvasFactorX - maxDistance));
            Canvas.SetLeft(bat2, (bat2PosXBot * canvasFactorX - maxDistance));
            //callibrator = new CallibrationPopUp();
        }

        public static void socketEmitPosition(int x, int y, int z)
        {
            int[] sendArray = karthesToWash(x, y, z);
            socket.Emit("setPosByDegrees", sendArray);
        }

        public static void socketEmitColor(String color)
        {
            
                socket.Emit("color", color);
            
        }

        private static void websocket_Opened(object sender, EventArgs e)
        {

            Console.Write("Opened" + "\n");
        }

        private static void websocket_Error(object sender, ErrorEventArgs e)
        {
            Console.Write(e.Exception + "\n");
            if (e.Exception.Data != null)
            {
                foreach (DictionaryEntry de in e.Exception.Data)
                {
                    Console.WriteLine("" + de.Key + "::::" + de.Value);
                }
            }
            else
            {
                Console.WriteLine(" Is Null");
            }
        }

        private static void socketMessage(object sender, EventArgs e)
        {
            Console.Write("Message");

        }

        private static void websocket_Closed(object sender, EventArgs e)
        {
            Console.Write("Closed \n");

        }

        void MainWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            sensor1.Stop();
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            sensor1.SkeletonFrameReady += sensor_PongReadyEvent1;
            sensor2.SkeletonFrameReady += sensor_pongReadyEvent2;
            sensor1.SkeletonFrameReady += sensor_faceSpamReady;
            sensor1.ColorFrameReady += runtime_VideoFrameReady1;
            sensor2.ColorFrameReady += runtime_VideoFrameReady2;
            sensor1.Start();
            sensor2.Start();
            //sensor1.ElevationAngle = 0;
            //sensor2.ElevationAngle = 0;
        }



        void sensor_faceSpamReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            
            if (mode == 1 && false)
            {
                using (SkeletonFrame skeletonframe = e.OpenSkeletonFrame())
                {
                    if (skeletonframe != null && skeletonData1 != null)
                    {
                        skeletonframe.CopySkeletonDataTo(skeletonData1);

                        Skeleton skeleton1 = skeletonData1.Where(s => s.TrackingState == SkeletonTrackingState.Tracked).FirstOrDefault();

                        if (skeleton1 != null)
                        {
                            Joint head = skeleton1.Joints[JointType.Head];
                            DepthImagePoint headPoint = sensor1.CoordinateMapper.MapSkeletonPointToDepthPoint(head.Position, DepthImageFormat.Resolution640x480Fps30);

                            int[] bla = karthesToWash(head.Position.X * -1000, head.Position.Z * 1000, (head.Position.Y - 2) * 1000);
                            socket.Emit("setPosByDegrees", bla);
                        }
                    }
                }
            }
        }

        void sensor_PongReadyEvent1(object sender, SkeletonFrameReadyEventArgs e)
        {
            //erkennt er gar nicht
            if (mode == 0 )
            {
                using (SkeletonFrame skeletonframe = e.OpenSkeletonFrame())
                {
                    if (skeletonframe != null && skeletonData1 != null)
                    {
                        skeletonframe.CopySkeletonDataTo(skeletonData1);

                        Skeleton skeleton1 = skeletonData1.Where(s => s.TrackingState == SkeletonTrackingState.Tracked).FirstOrDefault();

                        if (skeleton1 != null)
                        {
                            Joint handR = skeleton1.Joints[JointType.HandRight];
                            Joint handL = skeleton1.Joints[JointType.HandLeft];
                            DepthImagePoint handLeftPoint = sensor1.CoordinateMapper.MapSkeletonPointToDepthPoint(handL.Position, DepthImageFormat.Resolution640x480Fps30);
                            DepthImagePoint handRightPoint = sensor1.CoordinateMapper.MapSkeletonPointToDepthPoint(handR.Position, DepthImageFormat.Resolution640x480Fps30);
                            //bat1PosY = ((double)headPoint.Y / 480) * canvasHeight;
                            leftKRKPos = handR.Position.Y;
                            leftKRKPosX = handR.Position.X;
                            if (leftKTop != 0.0 && leftKBot != 0.0)
                            {
                                bat1PosY = Math.Abs(handR.Position.Y * 100 - rightKBot) / Math.Abs(rightKTop - rightKBot);
                                if (bat1PosY < 0)
                                {
                                    bat1PosY = 0;
                                }
                                if (bat1PosY > 1)
                                {
                                    bat1PosY = 1;
                                }
                                //bat2PosY = 1 - bat2PosY;
                                bat1PosY *= gameFieldHeight;

                                //Console.WriteLine("bat1-Position: " + (int)(100 * bat1PosY) + " bat2-Position: " + (int)(100 * bat2PosY) + " rightKTop: " + (int)(100 * rightKTop) + " rightKBot: " + (int)(100 * rightKBot) + " CanvasHeight: " + (int)(100 * canvasHeight));

                            }
                        }
                    }
                }
            }
        }

        void sensor_pongReadyEvent2(object sender, SkeletonFrameReadyEventArgs e)
        {
            if (mode == 0)
            {
                using (SkeletonFrame skeletonframe = e.OpenSkeletonFrame())
                {
                    if (skeletonframe != null && skeletonData2 != null)
                    {
                        skeletonframe.CopySkeletonDataTo(skeletonData2);

                        Skeleton skeleton2 = skeletonData2.Where(s => s.TrackingState == SkeletonTrackingState.Tracked).FirstOrDefault();

                        if (skeleton2 != null)
                        {
                            Joint handR = skeleton2.Joints[JointType.HandRight];
                            Joint handL = skeleton2.Joints[JointType.HandLeft];
                            DepthImagePoint handLeftPoint = sensor2.CoordinateMapper.MapSkeletonPointToDepthPoint(handL.Position, DepthImageFormat.Resolution640x480Fps30);
                            DepthImagePoint handRightPoint = sensor2.CoordinateMapper.MapSkeletonPointToDepthPoint(handR.Position, DepthImageFormat.Resolution640x480Fps30);
                            //bat1PosY = ((double)headPoint.Y / 480) * canvasHeight;
                            rightKRKPos = handR.Position.Y;
                            rightKRKPosX = handR.Position.X;
                            if (rightKTop != 0.0 && rightKBot != 0.0)
                            {

                                bat2PosY = Math.Abs(handR.Position.Y *100 - rightKBot) / Math.Abs(rightKTop - rightKBot);
                                if (bat2PosY < 0)
                                {
                                    bat2PosY = 0;
                                }
                                if (bat2PosY > 1)
                                {
                                    bat2PosY = 1;
                                }
                                //bat2PosY = 1 - bat2PosY;
                                bat2PosY *= gameFieldHeight;



                               
                               //Console.WriteLine("bat1-Position: " + (int)(100*bat1PosY) + " bat2-Position: " + (int)(100*bat2PosY) + " rightKTop: " + (int)(100*rightKTop) + " rightKBot: " + (int)(100*rightKBot) + " CanvasHeight: " + (int)(100*gameFieldHeight));

                            }
                        }
                    }
                }
            }
        }

        void setBallPos(float deltaTime)
        {
            
            double x = ballPosX;
            double y = ballPosY;
            double posX = ballPosX - gameFieldWidth / 2;
            double posY = ballPosY;
            Random random = new Random();
            //DebugShit: Console.WriteLine("distance1: " + squareDistanceToBat1 + "  distance2: " + squareDistanceToBat2);
            
            //New 1 is links 2 is rechts
            
            

            double bat1PosYBot = bat1PosY - batHalfLength;
            double bat1PosYTop = bat1PosY + batHalfLength;

            double bat2PosYBot = bat2PosY - batHalfLength;
            double bat2PosYTop = bat2PosY + batHalfLength;

            double ballNextX = ballPosX + movX;
            double ballNextY = ballPosY + movY;

            bool isHitBat1 = ballNextX < bat1PosXBot && ballNextX > bat1PosXBot - batWidth / 2 && ballNextY < bat1PosYTop && ballNextY > bat1PosYBot;
            bool isHitBat2 = ballNextX > bat2PosXBot && ballNextX < bat2PosXBot + batWidth / 2 && ballNextY < bat2PosYTop && ballNextY > bat2PosYBot;

            //With Distance
            /*
            double squareDistanceToBat1 = Math.Sqrt(Math.Pow(bat1PosX - ballPosX, 2) + Math.Pow(bat1PosY - ballPosY, 2));
            double squareDistanceToBat2 = Math.Sqrt(Math.Pow(bat2PosX - ballPosX, 2) + Math.Pow(bat2PosY - ballPosY, 2));
            double squareDistanceThreshold = maxDistance / canvasFactorY;
            bool isHitBat1 = squareDistanceToBat1 < squareDistanceThreshold;
            bool isHitBat2 = squareDistanceToBat2 < squareDistanceThreshold;*/

            //really Old
            //bool isHitBat1 = y + movY > ballPosY && y + movY < Canvas.GetTop(bat1) + batHeight && x + movX < Canvas.GetLeft(bat1) + batWidth && x + movX > Canvas.GetLeft(bat1);
            //bool isHitBat2 = y + movY > ballPosY && y + movY < Canvas.GetTop(bat2) + batHeight && x + movX < Canvas.GetLeft(bat2) + batWidth && x + movX > Canvas.GetLeft(bat2);

            double randomNumber = (random.Next(200)-100)/100;
            if (x + movX >= gameFieldWidth || x + movX <= 0)
            {
                if (x + movX >= gameFieldWidth)
                {
                    pointsR++;
                    socket.Emit("pongScore",1);
                }
                else
                {
                    pointsL++;
                    socket.Emit("pongScore",2);
                }
                socket.Emit("color", "#00ff00");
                movX = -movX + randomNumber;
                //Console.WriteLine("\n Punkte Rot: " + pointsL + "  Punkte Blau: " + pointsR);
                
            }
            if (isHitBat1)
            {
                //statt top bot einmal
                movY = ballPosY - (bat1PosYTop + bat1PosYTop)/2;
                movX = ballPosX - 0;
                socket.Emit("color", "#ff0000");
            }
            if (isHitBat2)
            {
                movY = ballPosY - (bat2PosYTop + bat2PosYTop) / 2;
                movX = ballPosX - gameFieldWidth;
                socket.Emit("color", "#0000ff");
            }
            if (y + movY >= gameFieldHeight || y + movY <= 0)
            {
                movY = -movY + randomNumber;
                movX -= randomNumber;
            }
            
            double betrag = Math.Sqrt(Math.Pow(movY, 2) + Math.Pow(movX, 2));
            movX /= betrag;
            movY /= betrag;
            movX *= speed * deltaTime;
            movY *= speed * deltaTime;
            
            ballPosX += movX;
            ballPosY += movY;
            

            //int[] bla = karthesToWash(posX, posY, 300);
            int[] washChangeData;
            if (!screenFacingAway)
            {
                washChangeData = karthesToWash(abstandToCanvas, -1 * (posX + (gameFieldWidth / 2) - gameFieldWidth / 2) + gameFieldWidth / 2 + canvasBLX, posY+(canvasBLY));
            }
            else
            {
                washChangeData = karthesToWash(abstandToCanvas,posX + (gameFieldWidth / 2) + canvasBLX, posY  + (canvasBLY));
            }
            socket.Emit("setPosByDegrees",washChangeData);
            //DebugShit: Console.WriteLine("Alpha: " + washChangeData[0] + "  Beta: " + washChangeData[1]);
            //Console.WriteLine("PosX: " + ballPosX + " PosY: " + ballPosY);
        }

        void runtime_VideoFrameReady1(object sender, ColorImageFrameReadyEventArgs e)
        {
            bool receivedData = false;
            byte[] pixelData = new byte[2];

            using (ColorImageFrame CFrame = e.OpenColorImageFrame())
            {
                

                if (CFrame == null)
                {
                    // The image processing took too long. More than 2 frames behind.
                }
                else
                {
                    pixelData = new byte[CFrame.PixelDataLength];
                    CFrame.CopyPixelDataTo(pixelData);
                    receivedData = true;
                }



            }

            if (receivedData)
            {
                source1 = BitmapSource.Create(640, 480, 96, 96,
                        PixelFormats.Bgr32, null, pixelData, 640 * 4);

                
            }
        }

        void runtime_VideoFrameReady2(object sender, ColorImageFrameReadyEventArgs e)
        {
            bool receivedData = false;
            byte[] pixelData = new byte[2];

            using (ColorImageFrame CFrame = e.OpenColorImageFrame())
            {


                if (CFrame == null)
                {
                    // The image processing took too long. More than 2 frames behind.
                }
                else
                {
                    pixelData = new byte[CFrame.PixelDataLength];
                    CFrame.CopyPixelDataTo(pixelData);
                    receivedData = true;
                }



            }

            if (receivedData)
            {
                source2 = BitmapSource.Create(640, 480, 96, 96,
                        PixelFormats.Bgr32, null, pixelData, 640 * 4);


            }
        }

        static int[] karthesToWash(double x, double y, double z)
        {


            int cX = 0;
            int cY = 1;
            //int cZ = 0;
            double betragFuerAlpha = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            double skalarAlpha = cY * y + cX * x;
            double alpha = Math.Acos(skalarAlpha / betragFuerAlpha);
            alpha /= Math.PI;
            alpha *= 180;
            if (x > 0)
            {
                alpha -= 180;
                alpha *= -1;
                alpha += 180;
            }
            //Beta
            /*
            double skalarBeta = x * x + y * y + z * 0;
            double betragFuerBeta = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2)) * Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            double beta = Math.Acos(skalarBeta / betragFuerBeta);
            beta /= Math.PI;
            beta *= 180;*/
            double distanceToMid = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            double beta = Math.Atan(z / distanceToMid);
            beta /= Math.PI;
            beta *= 180;
            beta += 25;
            /*betas[0] = betas[1];
            betas[1] = betas[2];
            betas[2] = beta;
            if (betas[1] > betas[0] && betas[1] > betas[2] && distanceToMid < 100)
            {
                dataSendOverThreshold = !dataSendOverThreshold;
            }
            if (dataSendOverThreshold)
            {
                beta -= 115;
                beta *= -1;
                beta += 115;
                if (alpha > 180)
                {
                    alpha -= 180;
                }
                else
                {
                    alpha += 180;
                }
                if (alpha < 0)
                    alpha = 0;
            }*/

            int[] returnArray = new int[2];
            returnArray[0] = (int)alpha;
            returnArray[1] = (int)beta;
            //returnArray[1] = 0;

            return returnArray;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            mode = cmb.SelectedIndex;
            callibrator.Visible = false;
            switch (mode)
            {
                case 0:
                    if (callibrator.IsDisposed)
                    {
                        callibrator = new CallibrationPopUp();
                    }
                    callibrator.Visible= true;
                    break;
            }

        }
        /*public void callibrate()
        {
            int xSave = 1;
            int ySave = 1;
            int zSave = 1;
            while (callibrator.Visible && !callibrator.isFinished())
            {
                int x = callibrator.getX();
                int y = callibrator.getY();
                int z = callibrator.getZ();
                if (x != xSave || y != ySave || zSave != z)
                {
                    xSave = x;
                    ySave = y;
                    zSave = z;
                    int[] washChangeData = karthesToWash(x, y, z);
                    socket.Emit("setPosByDegrees", washChangeData);
                    Console.WriteLine("Alpha: " + washChangeData[0] + "  Beta: " + washChangeData[1]);
                }
            }
        }*/

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (xSlider != null && ySlider != null && zSlider != null)
            {
                xSave = xSlider.Value;
                ySave = ySlider.Value;
                zSave = zSlider.Value;
                sendKarthes(xSlider.Value, ySlider.Value, zSlider.Value);
                //DebugShit: Console.WriteLine("X:  " + xSave + "  Y:  " + ySave + "  Z:  " + zSave);
            }
        }

        private int[] lastArray;
        void sendKarthes(double x, double y, double z)
        {
            if (lastArray == null)
            {
                lastArray = karthesToWash(x, y, z);
            }
            if (socket != null)
            {
                int[] array = karthesToWash(x, y, z);
                if (array[0] > -2000 &&Math.Abs(array[0] - lastArray[0]) > 90)
                {
                    array[0] = lastArray[0];
                }
                if (Math.Abs(array[1] - lastArray[1]) > 90)
                {
                    array[1] = lastArray[1];
                }
                socket.Emit("setPosByDegrees", array);
                //DebugShit: Console.WriteLine("Alpha:  " + array[0] + "  Beta:  " + array[1]);
            }
        }

    }
}
