using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour {

    //public Mesh mesh;
    public Mesh[] meshes;
    public Material material;
    private Material[,] materials;

    public int maxDepth;
    private int depth;
    public float childScale;
    public float spawnProbability;
    public float maxRotationSpeed;
    private float rotationSpeed;
    public float maxTwist;

	// Use this for initialization
	void Start () {

        rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        transform.Rotate(Random.Range(-maxTwist, maxTwist), 0f, 0f);

        if(materials == null)
        {
            InitializeMaterials();
        }
        gameObject.AddComponent<MeshFilter>().mesh = meshes[Random.Range(0,2)];
        //gameObject.AddComponent<MeshRenderer>().material = material;
        gameObject.AddComponent<MeshRenderer>().material = materials[depth,Random.Range(0,2)];
        //lerp            a+(b-a)*t      t (0,1)
       // GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.white, Color.yellow, (float)depth / maxDepth);
        //the depth is used to control the initialize numbers
        if (depth < maxDepth)
        {
            StartCoroutine(CreateChildren());
            //"new" is used to construct a new instance of an object or a struct
            //"this" refers to the current object or struct whose method is being called
           // new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this,Vector3.up);
           // new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.right);
        }
	}

    private static Vector3[] childDirections =
    {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back
    };

    private static Quaternion[] childQrientation =
    {
        Quaternion.identity,
        Quaternion.Euler(0f,0f,-90f),
        Quaternion.Euler(0f,0f,90f),
        Quaternion.Euler(90f,0f,0f),
        Quaternion.Euler(-90f,0f,0f)
    };

    //IEnumerator is the concept of going through some collection one item at a time(include iterators)
    private IEnumerator CreateChildren()
    {
        ///to make enumeration possible,you need to keep track of your progress,so you may need yield
       // yield return new WaitForSeconds(0.5f);
       // new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.up,Quaternion.identity);
       // yield return new WaitForSeconds(0.5f);
       // new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.right,Quaternion.Euler(0f,0f,-90f));
       // yield return new WaitForSeconds(0.5f);
       // new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, Vector3.left,Quaternion.Euler(0f,0f,90f));
       for(int i = 0;i<childDirections.Length;i++)
        {   if(Random.value < spawnProbability)
            {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, i);
            }
        }

    }
    ///Here I will say something about coroutines,When I create a coroutine in Unity,I am creating an iterator
    ///when I meet the StartCoroutine method,it will get stored and get asked for its next item every fram,until its finished
    /// public void Initialize(Fractal parent,Vector3 direction,Quaternion orientation)
    public void Initialize(Fractal parent,int childIndex)
    {

        // mesh = parent.mesh;
        meshes = parent.meshes;
        // material = parent.material;
        materials = parent.materials;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        childScale = parent.childScale;
        spawnProbability = parent.spawnProbability;
        maxRotationSpeed = parent.maxRotationSpeed;
        maxTwist = parent.maxTwist;

     
        //a child needs to make the parent of its transform component equal to its fractal parents transform
        //the parent of the transform is the parent transform
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = childQrientation[childIndex];

    }
	
    private void InitializeMaterials()
    {
        materials = new Material[maxDepth + 1,2];
        for (int i = 0; i <= maxDepth; i++)
        {
            float t = i / (maxDepth - 1f);
            t *= t;
            materials[i,0] = new Material(material);
            materials[i,0].color = Color.Lerp(Color.white, Color.yellow, t);
            materials[i, 1] = new Material(material);
            materials[i, 1].color = Color.Lerp(Color.white, Color.cyan, t);
        }
        materials[maxDepth,0].color = Color.magenta;
        materials[maxDepth, 1].color = Color.red;
    }
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
	}
}
