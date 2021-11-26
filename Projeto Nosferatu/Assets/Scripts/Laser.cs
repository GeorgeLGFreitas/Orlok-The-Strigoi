using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Color corLaser = Color.red;

    public float DistanciaDoLaser = 100;
    public float LarguraInicial = 0.02f;
    public float LarguraFinal = 0.1f;

    private GameObject luzColisao;
    private Vector3 posicaoLuz;
    public bool ligado;

    private void Start()
    {
        luzColisao = new GameObject();
        luzColisao.AddComponent<Light>();
        luzColisao.GetComponent<Light>().intensity = 8;
        luzColisao.GetComponent<Light>().bounceIntensity = 8;
        luzColisao.GetComponent<Light>().range = LarguraFinal * 2;
        luzColisao.GetComponent<Light>().color = corLaser;
        posicaoLuz = new Vector3(0, 0, LarguraFinal);

        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));
        lineRenderer.startColor = corLaser;
        lineRenderer.endColor = corLaser;
        lineRenderer.startWidth = LarguraInicial;
        lineRenderer.endWidth = LarguraFinal;
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        if (ligado)
        {
            luzColisao.SetActive(true);

            Vector3 pontoFinalDoLaser = transform.position + transform.forward * DistanciaDoLaser;

            RaycastHit pontoDeColisao;
            if (Physics.Raycast(transform.position, transform.forward, out pontoDeColisao, DistanciaDoLaser))
            {
                GetComponent<LineRenderer>().SetPosition(0, transform.position);
                GetComponent<LineRenderer>().SetPosition(1, pontoDeColisao.point);
                luzColisao.transform.position = (pontoDeColisao.point - posicaoLuz);

                if (pontoDeColisao.collider.tag == "TriggerVermelho")
                {
                    FindObjectOfType<MausoleuManager>().triggerVermelho = true;
                }
                if (pontoDeColisao.collider.tag == "TriggerAzul")
                {
                    FindObjectOfType<MausoleuManager>().triggerAzul = true;
                }
                if (pontoDeColisao.collider.tag == "TriggerVerde")
                {
                    FindObjectOfType<MausoleuManager>().triggerVerde = true;
                }
                if (pontoDeColisao.collider.tag == "TriggerAmarelo")
                {
                    FindObjectOfType<MausoleuManager>().triggerAmarelo = true;
                }
                else
                {
                    FindObjectOfType<MausoleuManager>().triggerAzul = false;
                }
            }
            else
            {
                GetComponent<LineRenderer>().SetPosition(0, transform.position);
                GetComponent<LineRenderer>().SetPosition(1, pontoFinalDoLaser);
                luzColisao.transform.position = pontoFinalDoLaser;
            }
        }
        else
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, transform.position);
        }
    }
}
