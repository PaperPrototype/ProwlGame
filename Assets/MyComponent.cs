using Prowl.Runtime;
using Prowl.Vector;

public class MyComponent : MonoBehaviour
{
    public string HAHAHAHA;

    public AssetRef<MeshCollider> meshCol;

    private Camera cameraGO;

    public override void Start()
    {
        cameraGO = Scene.FindObjectsOfType<Camera>()[0];
    }

    public override void Update()
    {
        // Camera movement
        Float2 movement = Float2.Zero;
        if (Input.GetKey(KeyCode.W)) movement += Float2.UnitY;
        if (Input.GetKey(KeyCode.S)) movement -= Float2.UnitY;
        if (Input.GetKey(KeyCode.A)) movement -= Float2.UnitX;
        if (Input.GetKey(KeyCode.D)) movement += Float2.UnitX;

        // forward/back
        cameraGO.Transform.Position += cameraGO.Transform.Forward * movement.Y * 10f * Time.DeltaTime;
        // left/right
        cameraGO.Transform.Position += cameraGO.Transform.Right * movement.X * 10f * Time.DeltaTime;

        // up/down
        float upDown = 0;
        if (Input.GetKey(KeyCode.E)) upDown += 1;
        if (Input.GetKey(KeyCode.Q)) upDown -= 1;
        cameraGO.Transform.Position += Float3.UnitY * upDown * 10f * Time.DeltaTime;

        // rotate with mouse
        if (Input.GetMouseButton(1))
        {
            Float2 delta = Input.MouseDelta;
            cameraGO.Transform.LocalEulerAngles += new Float3(delta.Y, delta.X, 0) * 0.1f;
        }
    }
}
