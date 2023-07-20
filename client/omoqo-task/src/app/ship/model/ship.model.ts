export interface ShipList {
  total: number;
  data: ShipItem[];
}

export interface ShipItem {
  id: number;
  name: string;
  length: number;
  width: number;
}

export interface Ship {
  id: number;
  name: string;
  length: number;
  width: number;
}
