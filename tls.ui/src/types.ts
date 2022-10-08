export type Product = {
  id: string;
  name: string;
  sizeName: string;
  sizeValue: number;
  imageUrl: string;
  price: number;
};

export type ProductWithQuantity = {
  productId: string;
  unitPrice: number;
  quantity: number;
};

export type Order = {
  name: string;
  contact: string;
  products: ProductWithQuantity[];
};

export type ProductSize = {
  name: string;
  value: number;
};

export type ProductView = {
  id: string;
  name: string;
  imageUrl: string;
  size: ProductSize;
  price: number;
  quantity: number;
};

// compare product by size first, then by name
export const compareProduct = (a: ProductView, b: ProductView) => {
  if (a.size.value > b.size.value) {
    return 1;
  } else if (a.size.value < b.size.value) {
    return -1;
  }
  return a.name.localeCompare(b.name);
};

// calculate the total cost of the products selected
export const calculateTotalCostFromMap = (products: Map<string, ProductView>) =>
  calculateTotalCostFromArray(Array.from(products.values()));

export const calculateTotalCostFromArray = (products: ProductView[]) =>
  products.reduce(
    (previousValue, currentValue) =>
      previousValue + currentValue.price * currentValue.quantity,
    0
  );
