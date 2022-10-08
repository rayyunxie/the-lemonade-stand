import { AxiosInstance } from 'axios';
import { Order, Product } from './types';

export async function getProducts(
  httpClient: AxiosInstance
): Promise<Product[]> {
  const response = await httpClient.get<Product[]>('/products');
  return response.data;
}

export async function createOrder(httpClient: AxiosInstance, order: Order) {
  const response = await httpClient.post('/orders', order);
  return response.data;
}
