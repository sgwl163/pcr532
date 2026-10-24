/** Classic 4K changes from four-block to sixteen-block sectors at block 128. */
export function classicSector(address: number): number {
  return address < 128
    ? Math.floor(address / 4)
    : 32 + Math.floor((address - 128) / 16);
}

export function classicTrailer(address: number): boolean {
  return address < 128 ? address % 4 === 3 : (address - 128) % 16 === 15;
}
