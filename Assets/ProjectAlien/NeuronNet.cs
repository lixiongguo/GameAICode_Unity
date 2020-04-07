using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuron
{
    public List<float> weights;
    public Neuron(int numInputs)
    {
        //注意bias也算是一个权重！
        for (int i = 0; i < numInputs + 1; i++)
        {
            weights.Add(Random.Range(-1, 1));
        }
    }
}
public class NeuronLayer
{
    public int numNeurons;
    public List<Neuron> neurons;
    public NeuronLayer(int numInputsPerNeuron, int numNeurons)
    {
        this.numNeurons = numNeurons;
        for (int i = 0; i < numNeurons; i++)
        {
            neurons.Add(new Neuron(numInputsPerNeuron));
        }
    }
}
public class NeuronNet
{
    int numInputs;
    int numOutputs;
    int numHiddenLayer;
    int neuronsPerHiddenLayer;
    List<NeuronLayer> neuronLayers;

    public NeuronNet()
    {
        this.numInputs = Params.iNumInputs;
        this.numOutputs = Params.iNumOutputs;
        this.numHiddenLayer = Params.iNumHidden;
        this.neuronsPerHiddenLayer = Params.iNeuronsPerHiddenLayer;
    }
    void CreateNet()
    {
        //输入层
        if (numHiddenLayer > 0)
        {
            neuronLayers.Add(new NeuronLayer(numInputs, neuronsPerHiddenLayer));
            //隐藏层
            for (int i = 0; i < numHiddenLayer - 1; i++)
            {
                neuronLayers.Add(new NeuronLayer(neuronsPerHiddenLayer, neuronsPerHiddenLayer));
            }
            //输出层
            neuronLayers.Add(new NeuronLayer(neuronsPerHiddenLayer, numOutputs));

        }
        else
        {
            neuronLayers.Add(new NeuronLayer(numInputs, numOutputs));
        }

    }
    float Sigmoid(float netInput, float response)
    {
        return (1 / (1 + Mathf.Exp(-netInput / response)));
    }
    public List<float> Update(List<float> inputs)
    {
        List<float> outputs = new List<float>();
        if (inputs.Count != numInputs)
        {
            Debug.Log("Input Size Error");
            return outputs;
        }
        for (int i = 0; i < numHiddenLayer + 1; i++)
        {
            if (i > 0)
                inputs = outputs;
            outputs.Clear();
            NeuronLayer curLayer = neuronLayers[i];
            for (int j = 0; j < neuronLayers[i].numNeurons; j++)
            {
                Neuron curNeuron = curLayer.neurons[j];
                if (inputs.Count != curNeuron.weights.Count - 1)
                {
                    Debug.Log("Layer " + i + " Neuron " + j + " Error");
                    return null;
                }
                float neuronOutput = 0;
                for (int k = 0; k <= curNeuron.weights.Count; k++)
                {
                    if (k < curNeuron.weights.Count)
                        neuronOutput += inputs[k] * curNeuron.weights[k];
                    else
                        neuronOutput = Params.dBias * curNeuron.weights[k];// bias
                }
                neuronOutput = Sigmoid(neuronOutput, Params.dActivationResponse);
                outputs.Add(neuronOutput);
            }

        }
        return outputs;
    }
    public int GetNumberOfWeights()
    {
        int weights = 0;
        for (int i = 0; i < numHiddenLayer + 1; ++i)
        {
            for (int j = 0; j < neuronLayers[i].numNeurons; ++j)
            {
                for (int k = 0; k < neuronLayers[i].neurons[j].weights.Count; ++k)

                    weights++;

            }
        }

        return weights;
    }

    public void PutWeights(List<float> weights)
    {
        int cWeight = 0;

        //for each layer
        for (int i = 0; i < numHiddenLayer + 1; ++i)
        {

            //for each neuron
            for (int j = 0; j < neuronLayers[i].numNeurons; ++j)
            {
                //for each weight
                for (int k = 0; k < neuronLayers[i].neurons[j].weights.Count; ++k)
                {
                    neuronLayers[i].neurons[j].weights[k] = weights[cWeight++];
                }
            }
        }

    }
    public List<float> GetWeights()
    {
        List<float> weights = new List<float>();
        for(int i = 0; i<numHiddenLayer + 1; i++)
        { 
            for(int j=0; j <neuronLayers[i].numNeurons;j++)
            {
                for (int k = 0; k < neuronLayers[i].neurons[j].weights.Count; k++)
                {
                    weights.Add(neuronLayers[i].neurons[j].weights[k]);
                }
            }
        }
        return weights;
    }

}
