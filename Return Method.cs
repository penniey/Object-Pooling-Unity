    private IEnumerator ReturnTextToPool(GameObject textObj, float delay)
    {
        yield return new WaitForSeconds(delay);
        textObj.SetActive(false);
    }
