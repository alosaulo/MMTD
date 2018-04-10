using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class CarController : MonoBehaviour {

    public float speed;

    Rigidbody myBody;

    PointType pointOrientation;

    XmlSerializer serializer;

    string pointControl = "";

    public void DeserializerPoint(string msg)
    {
        using (TextReader textReader = new StringReader(msg))
        {
            pointOrientation = (PointType)serializer.Deserialize(textReader);
        }
    }

    // Use this for initialization
    void Start () {
        serializer = new XmlSerializer(typeof(PointType), new XmlRootAttribute("Point"));
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        pointControl = ServerManager.message;
        if (pointControl.Length > 0)
        {
            DeserializerPoint(pointControl);
            Move();
        }
        else {
            float HorizontalValue = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float VerticalValue = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            Vector3 movement = new Vector3(HorizontalValue, myBody.velocity.y, VerticalValue);
            myBody.velocity = movement;
        }
    }

    void Move() {
        Vector3 movement;
        if (Mathf.Abs(pointOrientation.Position.X) >= 2) {
            movement = new Vector3((pointOrientation.Position.X*-1) * speed * Time.deltaTime, myBody.velocity.y, myBody.velocity.z);
            myBody.velocity = movement;
        }
        if (Mathf.Abs(pointOrientation.Position.Y) >= 2) {
            movement = new Vector3(myBody.velocity.x, myBody.velocity.y, (pointOrientation.Position.Y*-1) * speed * Time.deltaTime);
            myBody.velocity = movement;
        }
    }

}
