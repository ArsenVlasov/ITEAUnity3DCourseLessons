using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PressingButtonByBall : MonoBehaviour
{
    [SerializeField] private Color _buttonPressedColor = Color.red;
    [SerializeField] private Text _countdownTextField;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private float _power = 10.0f;
    [SerializeField] private float _radius = 5.0f;
    [SerializeField] private float _upForce = 1.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == TagName.Ball.ToString())
        {
            Debug.Log("Button was pressed...");
            transform.GetComponent<Renderer>().material.color = _buttonPressedColor;
            Debug.Log("Button color was changed...");
            _countdownTextField.gameObject.SetActive(true);
            Debug.Log("Countdown have been started...");
            StartCoroutine(StartCountdown());
            Debug.Log("Countdown was closed...");
            _countdownTextField.gameObject.SetActive(false);
            Debug.Log("Bomb just start detonation...");
            Invoke(nameof(Detonate), 3);
        }
    }

    private void Detonate()
    {
        Vector3 explosionPosition = _bomb.transform.position;
        _bomb.SetActive(false);
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, _radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_power, explosionPosition, _radius, _upForce, ForceMode.Impulse);
            }
        }
    }

    private IEnumerator StartCountdown()
    {
        _countdownTextField.text = "3...";
        yield return new WaitForSeconds(1.0f);
        _countdownTextField.text = "2...";
        yield return new WaitForSeconds(1.0f);
        _countdownTextField.text = "1..";
        yield return new WaitForSeconds(1.0f);
        _countdownTextField.text = "RUN AWAY!";
        yield return new WaitForSeconds(1.0f);
        _countdownTextField.text = "";
        yield return null;

    }
}
