import type { CalculatorRequest, CalculatorResponse } from '@/types/types';
import axios from 'axios';



const api = axios.create({
    baseURL: 'https://localhost:7114/api',
});

async function performOperation(request: CalculatorRequest): Promise<CalculatorResponse> {
    try {
        const response = await api.post<CalculatorResponse>('/perform-operation', request);
        return response.data;
    } catch (error) {
        console.error(error);
        throw new Error('Failed to perform operation');
    }
}

export { performOperation };