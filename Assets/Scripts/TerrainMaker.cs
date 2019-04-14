using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMaker : MonoBehaviour
{

    public GameObject ground = null;
    public Vector3 testRay = new Vector3(1,1,1);
    public GameObject tree1 = null;
    public GameObject tree2 = null;
    public GameObject tree3 = null;
    public GameObject rocks = null;
    public int[] arr= new int[8];
    public Transform player = null;
    public GameObject planeobj = null;
    public int[] treeCount =new int[3] {20000,1000,1000};
    public int rockCount = 20000;
    public Vector3 playerpos2d = Vector3.zero;
    public Vector3 groundDirection =Vector3.zero;  
    public int groundCopyNO = 100;
    public Vector3 heading;
    public int groundCopy = 10;
    public int extraValues = 5;
    int ci = 0, cj = 0, li = 0, lj = 0, ni = 0, nj = 0;
    private Vector3[,] groundPosition=new Vector3[201,201];
    public Vector3[] tree1pos = new Vector3[20000];
    public Vector3[] tree2pos = new Vector3[1000];
    public Vector3[] tree3pos = new Vector3[1000];
    public Vector3[] rockpos = new Vector3[20000];
    void Start()
    {

    

        int i,j,pi=-groundCopyNO*30,pj=-groundCopyNO*30;
        for (i = -groundCopyNO; i <= groundCopyNO; i++)
        {
            pj = -groundCopyNO*30;
            for (j = -groundCopyNO; j <= groundCopyNO; j++)
            {
                groundPosition[i + groundCopyNO, j + groundCopyNO] = new Vector3(pi, 0, pj);
                pj += 30;
            }
            pi += 30;
        }
        meshAssign();
        treePosAssign();


        createNewGround();
        TreeCreater(tree1, new Vector3(615, 0, 615), new Vector3(-615, 0, 615), new Vector3(-615, 0, -615), new Vector3(615, 0, -615), tree1pos, "tree");
        TreeCreater(rocks, new Vector3(615, 0, 615), new Vector3(-615, 0, 615), new Vector3(-615, 0, -615), new Vector3(615, 0, -615), rockpos, "rock");

    }
    void Update()
    {
 
        if (Input.GetKeyUp(KeyCode.X))
        {
      
        }

      
        playerpos2d = new Vector3(player.position.x, 0, player.position.z);
       
        Vector3 heading = new Vector3(player.position.x - playerpos2d.x, player.position.y - playerpos2d.y, player.position.z - playerpos2d.z);
        RaycastHit[] hits = null;
        hits = Physics.RaycastAll(player.position, -heading, 100.0f);
        Debug.DrawRay(player.position, -heading, Color.green);
        if (hits.Length > 0)
        {
            for(int k = 0; k < hits.Length; k++)
            {
                if (hits[k].collider)
                {
                    if (hits[k].collider.name.Contains("groundaa"))
                    {
                            ci = int.Parse(getBetween(hits[k].collider.name,"aa","bb"));
                            cj = int.Parse(getBetween(hits[k].collider.name, "bb", "cc"));
                        

                    }
                }
               
            }
            
        }
     //   Debug.Log("ci: " + ci + " cj: " + cj);
        if (li != ci || lj != cj)
        {
            if(ci == li + 1)
            {
                ni = ci + 20;
                createNewGround(ni, cj, 'i','p');
                TreeCreater(tree1, new Vector3(30*ni+15, 0, cj*30-615), new Vector3(30*ni+15, 0, cj*30+615), new Vector3(30*ni-15, 0, cj*30+615), new Vector3(30*ni-15, 0, cj*30-615), tree1pos,"tree");
                TreeCreater(rocks, new Vector3(30 * ni + 15, 0, cj*30 - 615), new Vector3(30 * ni + 15, 0, cj*30 + 615), new Vector3(30 * ni - 15, 0, cj*30 + 615), new Vector3(30 * ni - 15, 0, cj*30 - 615), rockpos, "rock");
            }
            if (ci == li - 1)
            {
                ni = ci - 20;
                createNewGround(ni, cj, 'i','m');
                TreeCreater(tree1, new Vector3(30 * ni + 15, 0, cj*30 - 615), new Vector3(30 * ni + 15, 0, cj*30 + 615), new Vector3(30 * ni - 15, 0, cj*30 + 615), new Vector3(30 * ni - 15, 0, cj*30 - 615), tree1pos,"tree");
                TreeCreater(rocks, new Vector3(30 * ni + 15, 0, cj*30 - 615), new Vector3(30 * ni + 15, 0, cj*30 + 615), new Vector3(30 * ni - 15, 0, cj*30 + 615), new Vector3(30 * ni - 15, 0, cj*30 - 615), rockpos, "rock");

            }
            if (cj == lj + 1)
            {
                nj = cj + 20;
                createNewGround(ci, nj, 'j','p');
                TreeCreater(tree1, new Vector3(ci*30 - 615 , 0, nj*30+15), new Vector3(ci*30 + 615, 0,nj*30+15), new Vector3(ci*30 + 615, 0, 30 * nj - 15 ), new Vector3(ci*30 - 615, 0, 30 * nj - 15), tree1pos,"tree");
                TreeCreater(rocks, new Vector3(ci*30 - 615, 0, nj * 30 + 15), new Vector3(ci*30 + 615, 0, nj * 30 + 15), new Vector3(ci*30 + 615, 0, 30 * nj - 15), new Vector3(ci*30 - 615, 0, 30 * nj - 15), rockpos, "rock");
                Debug.Log(ci);
                Debug.Log(ci + 615);
            }
            if (cj == lj - 1)
            {
                nj = cj - 20;
                createNewGround(ci, nj, 'j','m');
                TreeCreater(tree1, new Vector3(ci*30 - 615, 0, nj * 30 + 15), new Vector3(ci*30 + 615, 0, nj * 30 + 15), new Vector3(ci*30 + 615, 0, 30 * nj - 15), new Vector3(ci*30 - 615, 0, 30 * nj - 15), tree1pos,"tree");
                TreeCreater(rocks, new Vector3(ci*30 - 615, 0, nj * 30 + 15), new Vector3(ci*30 + 615, 0, nj * 30 + 15), new Vector3(ci*30 + 615, 0, 30 * nj - 15), new Vector3(ci*30 - 615, 0, 30 * nj - 15), rockpos, "rock");

            }
        }
        li = ci;
        lj = cj;
    }
    void createNewGround()
    {
        int i, j;
        for (i = -groundCopy; i <= groundCopy; i++)
        {

            for (j = -groundCopy; j <= groundCopy; j++)
            {
                GameObject obj = Instantiate(ground, groundPosition[i + groundCopyNO, j + groundCopyNO], ground.transform.rotation);
                obj.name = "groundaa" + i + "bb" + j+"cc";
                Debug.Log(" " + obj.name);
            }

        }
    }
    void createNewGround(int ni,int nj,char c,char d)
    {
        int i, j;
        if (c == 'i') {
            for (i = ni; i <= ni; i++)
            {

                for (j = nj-20; j <= nj+20; j++)
                {
                    GameObject obj = Instantiate(ground, groundPosition[i + groundCopyNO, j + groundCopyNO],ground.transform.rotation);
                    obj.name = "groundaa" + i + "bb" + j + "cc";
                    int a;
                    if (d == 'p')
                    {
                         a = i - 41;
                    }
                    else
                    {
                         a = i + 41;
                    }
                    
                    destroyObj("groundaa" + a + "bb" + j + "cc");
                }

            }

        }
        if (c == 'j')
        {
            for (i = ni-20; i <= ni+20; i++)
            {
                GameObject obj = Instantiate(ground, groundPosition[i + groundCopyNO, nj + groundCopyNO],ground.transform.rotation);
                obj.name = "groundaa" + i + "bb" + nj + "cc";
                int a;
                if (d == 'p')
                {
                    a = nj - 41;
                }
                else
                {
                    a = nj + 41;
                }
                destroyObj("groundaa" + i + "bb" + a + "cc");
            }
        }
       
    }
    public static string getBetween(string strSource, string strStart, string strEnd)
    {
        int Start, End;
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }
        else
        {
            return "";
        }
    }
    void meshAssign()
    {
        MeshFilter meshFilter = ground.AddComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;
        mesh.Clear();
        mesh.vertices = new Vector3[] { new Vector3(0, 0, 15), new Vector3(0, 0, -15), new Vector3(15, 0, 0), new Vector3(-15, 0, 0) };
        mesh.triangles = arr;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        MeshCollider meshCollider = ground.AddComponent<MeshCollider>();
        meshCollider.convex = true;
    }
    void destroyObj(string name)
    {
        GameObject temp = GameObject.Find(name);
        Destroy(temp);
    }
    void treePosAssign()
    {
        for(int i = 0; i < treeCount[0]; i++)
        {
            float xPos, zPos;
            xPos = Random.Range(-3015.0f, 3015.0f);
            zPos = Random.Range(-3015.0f, 3015.0f);
            tree1pos[i] = new Vector3(xPos, 0, zPos);
        }
        for (int i = 0; i < treeCount[1]; i++)
        {
            float xPos, zPos;
            xPos = Random.Range(-3015.0f, 3015.0f);
            zPos = Random.Range(-3015.0f, 3015.0f);
            tree2pos[i] = new Vector3(xPos, 0, zPos);
        }
        for (int i = 0; i < treeCount[2]; i++)
        {
            float xPos, zPos;
            xPos = Random.Range(-3015.0f, 3015.0f);
            zPos = Random.Range(-3015.0f, 3015.0f);
            tree3pos[i] = new Vector3(xPos, 0, zPos);
        }
        for (int i = 0; i < rockCount; i++)
        {
            float xPos, zPos;
            xPos = Random.Range(-3015.0f, 3015.0f);
            zPos = Random.Range(-3015.0f, 3015.0f);
            rockpos[i] = new Vector3(xPos, 0, zPos);
        }
    }
    public void TreeCreater(GameObject tree,Vector3 c1,Vector3 c2,Vector3 c3,Vector3 c4,Vector3[] treepos,string objName)
    {
       
        float x1=0, x2=0, z1=0, z2=0;
        if (c1.x == c2.x)
        {
            z1 = c1.z;
            z2 = c2.z;
            if (c1.z == c3.z)
            {
                x1 = c1.x;
                x2 = c3.x;
            }
            else
            {
                x1 = c1.x;
                x2 = c4.x;
            }
        }
        else if(c1.x==c3.x)
        {
            z1 = c1.z;
            z2 = c3.z;
            if (c1.z == c2.z)
            {
                x1 = c1.x;
                x2 = c2.x;
            }
            else
            {
                x1 = c1.x;
                x2 = c4.x;
            }
        }
        else if (c1.x == c4.x)
        {
            z1 = c1.z;
            z2 = c4.z;
            if (c1.z == c2.z)
            {
                x1 = c1.x;
                x2 = c2.x;
            }
            else
            {
                x1 = c1.x;
                x2 = c3.x;
            }
        }
        int tno = 0;
    //    Debug.Log("x1: " + x1 + " z1: " + z1);
      //  Debug.Log("x2: " + x2 + " z2: " + z2);
        for (int i = 0;i< treepos.Length; i++)
        {
            
            if (checkBet(treepos[i].x, x1, x2)&&checkBet(treepos[i].z,z1,z2))
            {
                tno++;
                GameObject ntree = Instantiate(tree,treepos[i],tree.transform.rotation);
                

                RaycastHit[] hits = null;
                Vector3 treepo = new Vector3(ntree.transform.position.x, 2, ntree.transform.position.z);
                hits = Physics.RaycastAll(treepo, new Vector3(0, -1, 0), 10.0f);
               
                if (hits.Length > 0)
                {
                    for (int k = 0; k < hits.Length; k++)
                    {
                        if (hits[k].collider)
                        { 
                          //  Debug.Log(tno+" Object Name: " + hits[k].collider.name);
                            if (hits[k].collider.name.Contains("groundaa"))
                            {
                               int nti = int.Parse(getBetween(hits[k].collider.name, "aa", "bb"));
                               int ntj = int.Parse(getBetween(hits[k].collider.name, "bb", "cc"));
                                ntree.name = objName+"aa" + nti + "bb" + ntj + "cc"+tno+"dd";
                                ntree.transform.parent = hits[k].collider.transform;
                            }
                        }

                    }

                }

            }
        }
    }
    bool checkBet(float no,float fno,float sno)
    {
        bool retVal = false;
        float sn = 0, bn = 0;
        bn = Mathf.Max(fno, sno);
        sn = Mathf.Min(fno, sno);
        if(no >= sn && no <= bn)
        {
            retVal = true;
        }
             
        return retVal;
    }



}
