using UnityEngine;

public class SpawnEffect : MonoBehaviour
{

    public float spawnEffectTime = 2;
    public float pause = 1;
    public AnimationCurve fadeIn;
    public float lifeTime;

    float remainingLifeTime;
    ParticleSystem ps;
    float timer = 0;
    Renderer _renderer;

    int shaderProperty;

    void Awake()
    {
        shaderProperty = Shader.PropertyToID("_cutoff");
        _renderer = GetComponent<Renderer>();
        ps = GetComponentInChildren<ParticleSystem>();

        var main = ps.main;
        main.duration = spawnEffectTime;
    }

    private void OnEnable()
    {
        remainingLifeTime = lifeTime;
        ps.Play();
    }

    void Update()
    {
        DoSomething();
        LifeTime();
    }

    private void LifeTime()
    {
        remainingLifeTime -= Time.deltaTime;
        if (remainingLifeTime <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void DoSomething()
    {
        if (timer < spawnEffectTime + pause)
        {
            timer += Time.deltaTime;
        }
        else
        {
            ps.Play();
            timer = 0;
        }

        _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate(Mathf.InverseLerp(0, spawnEffectTime, timer)));
    }
}
