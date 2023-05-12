// import axios, { type AxiosResponse } from 'axios';

// interface CalculatorRequest {
//     operand1: number;
//     operand2?: number;
//     operatorType: string;
// }

// interface CalculatorResult {
//     result: number | null;
//     isSuccess: boolean;
//     errorMessage: string | null;
// }

// async function calculate(request: CalculatorRequest): Promise<CalculatorResult> {
//     try {
//         const response= await axios.post<CalculatorResult>('/calculator', request);
//         return response.data;
//     } catch (error) {
//         console.error(error);
//         return { result: null, isSuccess: false, errorMessage: error.message };
//     }
// }

// export { CalculatorRequest, CalculatorResult, calculate };