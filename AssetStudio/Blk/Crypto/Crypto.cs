﻿using System;

namespace AssetStudio
{
    public static class Crypto
    {
        private static readonly byte[] SBox = new byte[] { 0xF7, 0xE7, 0xD8, 0xB8, 0x64, 0x31, 0xD1, 0x74, 0x88, 0xAA, 0xB4, 0x8B, 0x6A, 0xA3, 0xFC, 0x55, 0x59, 0xC5, 0x6D, 0xC9, 0x9A, 0x11, 0x2F, 0x37, 0xAD, 0x35, 0x15, 0x62, 0x61, 0x04, 0x44, 0x01, 0xDD, 0x47, 0x3D, 0xFF, 0x8F, 0x51, 0xAF, 0x0F, 0x19, 0x23, 0x92, 0x13, 0x00, 0x53, 0x4B, 0x67, 0x21, 0x1C, 0x1B, 0x94, 0xE2, 0x29, 0x9F, 0x4C, 0xFB, 0xBB, 0x75, 0xF0, 0xFE, 0x1F, 0xDB, 0xEF, 0x1D, 0xF1, 0x3A, 0x1A, 0x05, 0x06, 0xCE, 0xDE, 0x63, 0x0A, 0x6B, 0x2D, 0x28, 0x41, 0x6C, 0x0C, 0x42, 0xDC, 0x58, 0xB6, 0x39, 0x2E, 0xD2, 0xF6, 0x2B, 0xAC, 0x84, 0x96, 0x17, 0xF3, 0x3F, 0x8D, 0xAB, 0x95, 0xCD, 0x30, 0x0E, 0x66, 0x90, 0xF4, 0xED, 0xE0, 0x8E, 0xC2, 0x78, 0x2C, 0x7E, 0xF8, 0x5D, 0x02, 0x91, 0xFA, 0x3C, 0xDA, 0xB7, 0x6F, 0xF9, 0x4F, 0x14, 0x5E, 0xEA, 0x24, 0x56, 0x9E, 0xC1, 0xA5, 0x85, 0xD7, 0x08, 0x83, 0x4E, 0xF5, 0x76, 0x32, 0x86, 0x5C, 0xD3, 0x09, 0x5F, 0xFD, 0x36, 0x03, 0xEE, 0xE3, 0x34, 0x77, 0x79, 0x18, 0xBD, 0xDF, 0x97, 0x71, 0xBA, 0x65, 0x68, 0x7A, 0x54, 0x80, 0x48, 0x38, 0x5B, 0x4D, 0x5A, 0x7F, 0x0B, 0x7C, 0xA6, 0x7B, 0x25, 0xD6, 0x0D, 0x40, 0xD0, 0x07, 0x99, 0x9D, 0x93, 0x69, 0xD9, 0x8C, 0xB3, 0xB5, 0xA4, 0x1E, 0xCB, 0x33, 0x82, 0xE9, 0xC3, 0x60, 0xA7, 0xAE, 0x45, 0xBE, 0xB1, 0x46, 0xB2, 0x9C, 0x22, 0xC7, 0x81, 0x98, 0xA9, 0xD5, 0x6E, 0xE1, 0x10, 0xCA, 0xBC, 0x4A, 0x70, 0xD4, 0xC4, 0x72, 0x12, 0xCF, 0x2A, 0x87, 0x16, 0xC8, 0x73, 0xA1, 0x3E, 0x52, 0x50, 0xA8, 0x57, 0x27, 0xEC, 0xCC, 0x7D, 0xE4, 0xA0, 0x89, 0xBF, 0xE5, 0x8A, 0x20, 0xEB, 0xC0, 0xA2, 0x49, 0xB9, 0xE8, 0x26, 0xC6, 0xE6, 0xB0, 0x3B, 0x9B, 0xF2, 0x43, 0x5E, 0xB0, 0xE6, 0x0D, 0xF9, 0x87, 0xD7, 0x8A, 0xDF, 0xE7, 0x19, 0x99, 0x6F, 0xD5, 0x5B, 0x4E, 0xCB, 0xC2, 0x48, 0xD2, 0xF2, 0x44, 0x35, 0x03, 0xE9, 0x86, 0xD0, 0x95, 0x02, 0x4A, 0x04, 0x62, 0xC5, 0x9D, 0x1D, 0xE2, 0xFD, 0x53, 0x08, 0x8D, 0x5D, 0x75, 0xD9, 0x3F, 0x94, 0x59, 0x14, 0x29, 0x98, 0x76, 0x8C, 0x79, 0x2E, 0x8F, 0x39, 0x0C, 0x4C, 0xC8, 0xC0, 0x81, 0x9C, 0x10, 0xBB, 0xAF, 0xF7, 0xE5, 0xB2, 0xB3, 0xEE, 0x56, 0x57, 0xB8, 0xFA, 0x40, 0x7A, 0x72, 0x77, 0x24, 0x6C, 0xC6, 0x47, 0x3A, 0x74, 0xCF, 0x89, 0xB4, 0x9B, 0x26, 0xAA, 0x38, 0x09, 0xC3, 0x1C, 0xDE, 0x9F, 0xDD, 0x16, 0x1F, 0x55, 0xBD, 0xAD, 0xAC, 0x80, 0x4F, 0x64, 0x4B, 0x71, 0xB7, 0xF6, 0x06, 0x2B, 0xC7, 0x01, 0xEA, 0x46, 0xA6, 0xEB, 0x3D, 0xCA, 0x07, 0x34, 0x1B, 0xFF, 0x7C, 0x7D, 0x2D, 0x37, 0x67, 0x60, 0x9A, 0xC4, 0x97, 0x7F, 0xD6, 0xBE, 0xAE, 0x85, 0x25, 0x88, 0x65, 0xA2, 0x00, 0xB6, 0x8E, 0xD4, 0x6E, 0x1A, 0x63, 0x36, 0x92, 0xC1, 0xE1, 0x15, 0xA5, 0x58, 0x3B, 0x7E, 0x22, 0x2F, 0x84, 0x0F, 0x5C, 0x96, 0xB1, 0xF1, 0x6D, 0x8B, 0xF4, 0xA8, 0xB5, 0x0B, 0xFE, 0x23, 0xE3, 0xCE, 0xF8, 0xF5, 0x51, 0x45, 0x43, 0x18, 0x1E, 0xD1, 0xBA, 0xBC, 0x90, 0x21, 0x70, 0x30, 0xC9, 0x2A, 0xEC, 0x61, 0x7B, 0x66, 0x5F, 0x13, 0x33, 0x20, 0x6B, 0xCD, 0x3C, 0xA0, 0x93, 0x31, 0xB9, 0x05, 0x82, 0xFB, 0x3E, 0x17, 0x12, 0x6A, 0x0A, 0xCC, 0x4D, 0xA1, 0x73, 0x52, 0x78, 0xBF, 0x28, 0x50, 0x69, 0xDC, 0x68, 0x42, 0xE0, 0xA4, 0x2C, 0xEF, 0xF0, 0x11, 0xE8, 0x91, 0x49, 0x83, 0x5A, 0xF3, 0x32, 0xDB, 0xAB, 0xDA, 0x27, 0x0E, 0xED, 0xA3, 0xFC, 0x41, 0xA7, 0xA9, 0xD3, 0x9E, 0xE4, 0xD8, 0x54, 0x95, 0xAE, 0xF0, 0xD5, 0x73, 0x24, 0xD2, 0xA5, 0x99, 0x0B, 0x1B, 0xC4, 0x9A, 0xD8, 0x69, 0x6F, 0x25, 0xED, 0x8E, 0x91, 0x63, 0xF8, 0x35, 0x62, 0x5B, 0x94, 0x88, 0xB2, 0x5C, 0x0F, 0xDD, 0xA4, 0x7A, 0x1A, 0x12, 0xC6, 0x37, 0x44, 0xF1, 0x4E, 0xB9, 0x4D, 0x43, 0xD1, 0xAD, 0xEB, 0xB4, 0x46, 0x80, 0x30, 0x5E, 0xE4, 0x87, 0x6E, 0x0A, 0x82, 0xCF, 0x74, 0x38, 0xB5, 0xC1, 0xD6, 0x01, 0x05, 0xE8, 0x83, 0xA9, 0x6D, 0xCE, 0xA8, 0xC5, 0x51, 0xA3, 0x3F, 0xDA, 0x03, 0xD0, 0x3A, 0x39, 0x6C, 0x11, 0x97, 0x68, 0x54, 0xC0, 0x4B, 0xDF, 0x19, 0x0C, 0x21, 0x1F, 0x66, 0xBD, 0xE9, 0x61, 0x49, 0xC8, 0x42, 0xBC, 0xEC, 0x7F, 0xC3, 0x4F, 0x2E, 0xA1, 0x58, 0x3D, 0x81, 0xE3, 0x14, 0xB8, 0x02, 0x23, 0x9E, 0x77, 0x2B, 0x33, 0xA6, 0x93, 0x13, 0x34, 0x0E, 0x06, 0x45, 0xFB, 0x07, 0x75, 0x0D, 0x1E, 0x40, 0xAB, 0x7D, 0xF5, 0xBB, 0x55, 0xEF, 0x04, 0x65, 0x79, 0x2F, 0xCA, 0xF3, 0x29, 0xCB, 0xEA, 0x17, 0xF4, 0xE6, 0x71, 0x4C, 0x50, 0x26, 0xD9, 0x78, 0x5F, 0x09, 0x9C, 0x1C, 0x85, 0x31, 0x22, 0x9B, 0xC9, 0xE0, 0x8F, 0xAC, 0x57, 0x8B, 0x7C, 0x47, 0x7E, 0x16, 0xF7, 0x08, 0x5A, 0x59, 0x1D, 0xC7, 0xF9, 0x00, 0x2D, 0x60, 0x3C, 0x9F, 0x96, 0xA2, 0xBA, 0x20, 0x70, 0xF6, 0x48, 0xB0, 0x2C, 0x72, 0xE1, 0x64, 0xE7, 0xFF, 0xB7, 0x56, 0xA7, 0x53, 0x84, 0xD7, 0xE2, 0xD4, 0xA0, 0xB1, 0x8C, 0xE5, 0x2A, 0xDC, 0x15, 0x28, 0x5D, 0x3B, 0x36, 0x7B, 0x86, 0x6A, 0xDB, 0x10, 0xBE, 0x6B, 0xFE, 0x9D, 0x18, 0xDE, 0x76, 0xF2, 0xCD, 0xB6, 0x32, 0xFC, 0x41, 0xAF, 0xBF, 0x67, 0xB3, 0xAA, 0xC2, 0x8A, 0xFD, 0x89, 0xCC, 0xFA, 0x90, 0x98, 0x8D, 0x52, 0xD3, 0xEE, 0x92, 0x3E, 0x4A, 0x27, 0x2A, 0xD7, 0x9E, 0x02, 0x53, 0x63, 0xEA, 0xE9, 0x8F, 0x35, 0x22, 0x7F, 0xFE, 0xCA, 0x75, 0x46, 0x57, 0x94, 0xD9, 0x4E, 0xD2, 0xD4, 0x76, 0xA1, 0xC3, 0xD8, 0xBC, 0x9B, 0x84, 0x87, 0x91, 0x51, 0xB1, 0xAB, 0x81, 0x64, 0x47, 0xAF, 0x9D, 0x6A, 0x5B, 0x2D, 0xD6, 0x95, 0x77, 0x03, 0xC1, 0x10, 0xAD, 0x61, 0x0C, 0xBF, 0x11, 0x34, 0x7E, 0x01, 0x38, 0x20, 0x4B, 0xB6, 0x4A, 0x1A, 0x45, 0x99, 0x5F, 0x26, 0xBB, 0xC5, 0xCD, 0x23, 0xF1, 0xF7, 0xB4, 0x8E, 0xE1, 0xF8, 0x68, 0x56, 0x29, 0xD5, 0x3D, 0xEF, 0x12, 0x28, 0xC4, 0x2E, 0x79, 0xA6, 0x48, 0x85, 0x73, 0x14, 0xE4, 0xC6, 0x6B, 0x92, 0x30, 0x27, 0x93, 0x13, 0x0D, 0xE2, 0xC9, 0xF0, 0x65, 0xDF, 0xFB, 0xE3, 0x06, 0x2F, 0x8C, 0x4C, 0x18, 0x15, 0xD3, 0x49, 0x3E, 0x07, 0x59, 0xB0, 0x88, 0xA9, 0xC8, 0x3B, 0x86, 0xEE, 0x5C, 0x7A, 0x5E, 0xFF, 0x8D, 0xAC, 0x08, 0xE6, 0x60, 0x54, 0xA0, 0x7D, 0x40, 0x33, 0xA8, 0xFC, 0xE0, 0x37, 0x98, 0xBD, 0xEC, 0x09, 0xB2, 0x71, 0x58, 0x1F, 0xDE, 0x74, 0x89, 0x36, 0x52, 0x66, 0xA2, 0x3C, 0x96, 0x5D, 0x50, 0x90, 0x41, 0xF5, 0x17, 0x2B, 0x0B, 0xDC, 0xF6, 0x00, 0x83, 0xDD, 0x6D, 0xB5, 0x3A, 0x9C, 0xB8, 0x70, 0x7C, 0x43, 0x69, 0xFD, 0x32, 0x1B, 0xED, 0x0F, 0x55, 0x97, 0xC2, 0xFA, 0x39, 0x4F, 0x9A, 0x82, 0x19, 0xE7, 0x78, 0x6E, 0xCB, 0xA4, 0xBE, 0x24, 0xB3, 0xF3, 0xCC, 0xCF, 0x1C, 0xF9, 0x44, 0xA5, 0x1E, 0x80, 0x3F, 0xD0, 0x21, 0xA3, 0xE8, 0x31, 0x05, 0x16, 0x8A, 0xBA, 0x67, 0x0E, 0xE5, 0xB7, 0xD1, 0x42, 0x1D, 0xDB, 0x72, 0x6C, 0xA7, 0xCE, 0x04, 0x4D, 0xDA, 0xC7, 0x8B, 0x9F, 0x6F, 0x0A, 0x2C, 0xEB, 0xF2, 0x5A, 0x7B, 0xAA, 0x25, 0xC0, 0x62, 0xAE, 0xF4, 0xB9 };
        private static readonly byte[] GF256Exp = new byte[] { 0x01, 0x03, 0x05, 0x0F, 0x11, 0x33, 0x55, 0xFF, 0x1A, 0x2E, 0x72, 0x96, 0xA1, 0xF8, 0x13, 0x35, 0x5F, 0xE1, 0x38, 0x48, 0xD8, 0x73, 0x95, 0xA4, 0xF7, 0x02, 0x06, 0x0A, 0x1E, 0x22, 0x66, 0xAA, 0xE5, 0x34, 0x5C, 0xE4, 0x37, 0x59, 0xEB, 0x26, 0x6A, 0xBE, 0xD9, 0x70, 0x90, 0xAB, 0xE6, 0x31, 0x53, 0xF5, 0x04, 0x0C, 0x14, 0x3C, 0x44, 0xCC, 0x4F, 0xD1, 0x68, 0xB8, 0xD3, 0x6E, 0xB2, 0xCD, 0x4C, 0xD4, 0x67, 0xA9, 0xE0, 0x3B, 0x4D, 0xD7, 0x62, 0xA6, 0xF1, 0x08, 0x18, 0x28, 0x78, 0x88, 0x83, 0x9E, 0xB9, 0xD0, 0x6B, 0xBD, 0xDC, 0x7F, 0x81, 0x98, 0xB3, 0xCE, 0x49, 0xDB, 0x76, 0x9A, 0xB5, 0xC4, 0x57, 0xF9, 0x10, 0x30, 0x50, 0xF0, 0x0B, 0x1D, 0x27, 0x69, 0xBB, 0xD6, 0x61, 0xA3, 0xFE, 0x19, 0x2B, 0x7D, 0x87, 0x92, 0xAD, 0xEC, 0x2F, 0x71, 0x93, 0xAE, 0xE9, 0x20, 0x60, 0xA0, 0xFB, 0x16, 0x3A, 0x4E, 0xD2, 0x6D, 0xB7, 0xC2, 0x5D, 0xE7, 0x32, 0x56, 0xFA, 0x15, 0x3F, 0x41, 0xC3, 0x5E, 0xE2, 0x3D, 0x47, 0xC9, 0x40, 0xC0, 0x5B, 0xED, 0x2C, 0x74, 0x9C, 0xBF, 0xDA, 0x75, 0x9F, 0xBA, 0xD5, 0x64, 0xAC, 0xEF, 0x2A, 0x7E, 0x82, 0x9D, 0xBC, 0xDF, 0x7A, 0x8E, 0x89, 0x80, 0x9B, 0xB6, 0xC1, 0x58, 0xE8, 0x23, 0x65, 0xAF, 0xEA, 0x25, 0x6F, 0xB1, 0xC8, 0x43, 0xC5, 0x54, 0xFC, 0x1F, 0x21, 0x63, 0xA5, 0xF4, 0x07, 0x09, 0x1B, 0x2D, 0x77, 0x99, 0xB0, 0xCB, 0x46, 0xCA, 0x45, 0xCF, 0x4A, 0xDE, 0x79, 0x8B, 0x86, 0x91, 0xA8, 0xE3, 0x3E, 0x42, 0xC6, 0x51, 0xF3, 0x0E, 0x12, 0x36, 0x5A, 0xEE, 0x29, 0x7B, 0x8D, 0x8C, 0x8F, 0x8A, 0x85, 0x94, 0xA7, 0xF2, 0x0D, 0x17, 0x39, 0x4B, 0xDD, 0x7C, 0x84, 0x97, 0xA2, 0xFD, 0x1C, 0x24, 0x6C, 0xB4, 0xC7, 0x52, 0xF6, 0x01 };
        private static readonly byte[] GF256Log = new byte[] { 0x00, 0x00, 0x19, 0x01, 0x32, 0x02, 0x1A, 0xC6, 0x4B, 0xC7, 0x1B, 0x68, 0x33, 0xEE, 0xDF, 0x03, 0x64, 0x04, 0xE0, 0x0E, 0x34, 0x8D, 0x81, 0xEF, 0x4C, 0x71, 0x08, 0xC8, 0xF8, 0x69, 0x1C, 0xC1, 0x7D, 0xC2, 0x1D, 0xB5, 0xF9, 0xB9, 0x27, 0x6A, 0x4D, 0xE4, 0xA6, 0x72, 0x9A, 0xC9, 0x09, 0x78, 0x65, 0x2F, 0x8A, 0x05, 0x21, 0x0F, 0xE1, 0x24, 0x12, 0xF0, 0x82, 0x45, 0x35, 0x93, 0xDA, 0x8E, 0x96, 0x8F, 0xDB, 0xBD, 0x36, 0xD0, 0xCE, 0x94, 0x13, 0x5C, 0xD2, 0xF1, 0x40, 0x46, 0x83, 0x38, 0x66, 0xDD, 0xFD, 0x30, 0xBF, 0x06, 0x8B, 0x62, 0xB3, 0x25, 0xE2, 0x98, 0x22, 0x88, 0x91, 0x10, 0x7E, 0x6E, 0x48, 0xC3, 0xA3, 0xB6, 0x1E, 0x42, 0x3A, 0x6B, 0x28, 0x54, 0xFA, 0x85, 0x3D, 0xBA, 0x2B, 0x79, 0x0A, 0x15, 0x9B, 0x9F, 0x5E, 0xCA, 0x4E, 0xD4, 0xAC, 0xE5, 0xF3, 0x73, 0xA7, 0x57, 0xAF, 0x58, 0xA8, 0x50, 0xF4, 0xEA, 0xD6, 0x74, 0x4F, 0xAE, 0xE9, 0xD5, 0xE7, 0xE6, 0xAD, 0xE8, 0x2C, 0xD7, 0x75, 0x7A, 0xEB, 0x16, 0x0B, 0xF5, 0x59, 0xCB, 0x5F, 0xB0, 0x9C, 0xA9, 0x51, 0xA0, 0x7F, 0x0C, 0xF6, 0x6F, 0x17, 0xC4, 0x49, 0xEC, 0xD8, 0x43, 0x1F, 0x2D, 0xA4, 0x76, 0x7B, 0xB7, 0xCC, 0xBB, 0x3E, 0x5A, 0xFB, 0x60, 0xB1, 0x86, 0x3B, 0x52, 0xA1, 0x6C, 0xAA, 0x55, 0x29, 0x9D, 0x97, 0xB2, 0x87, 0x90, 0x61, 0xBE, 0xDC, 0xFC, 0xBC, 0x95, 0xCF, 0xCD, 0x37, 0x3F, 0x5B, 0xD1, 0x53, 0x39, 0x84, 0x3C, 0x41, 0xA2, 0x6D, 0x47, 0x14, 0x2A, 0x9E, 0x5D, 0x56, 0xF2, 0xD3, 0xAB, 0x44, 0x11, 0x92, 0xD9, 0x23, 0x20, 0x2E, 0x89, 0xB4, 0x7C, 0xB8, 0x26, 0x77, 0x99, 0xE3, 0xA5, 0x67, 0x4A, 0xED, 0xDE, 0xC5, 0x31, 0xFE, 0x18, 0x0D, 0x63, 0x8C, 0x80, 0xC0, 0xF7, 0x70, 0x07 };
        private static readonly byte[] InitialKey = new byte[] { 0xE3, 0xFC, 0x2D, 0x26, 0x9C, 0xC5, 0xA2, 0xEC, 0xD3, 0xF8, 0xC6, 0xD3, 0x77, 0xC2, 0x49, 0xB9 };
        private static readonly byte[] Mhy0ShiftRow = new byte[] { 0x0B, 0x02, 0x08, 0x0C, 0x01, 0x05, 0x00, 0x0F, 0x06, 0x07, 0x09, 0x03, 0x0D, 0x04, 0x0E, 0x0A, 0x04, 0x05, 0x07, 0x0A, 0x02, 0x0F, 0x0B, 0x08, 0x0E, 0x0D, 0x09, 0x06, 0x0C, 0x03, 0x00, 0x01, 0x08, 0x00, 0x0C, 0x06, 0x04, 0x0B, 0x07, 0x09, 0x05, 0x03, 0x0F, 0x01, 0x0D, 0x0A, 0x02, 0x0E };
        private static readonly byte[] Mhy0Key = new byte[] { 0x48, 0x14, 0x36, 0xED, 0x8E, 0x44, 0x5B, 0xB6 };
        private static readonly byte[] Mhy0Mul = new byte[] { 0xA7, 0x99, 0x66, 0x50, 0xB9, 0x2D, 0xF0, 0x78 };

        private static readonly ulong ConstKey = 0x567BA22BABB08098;

        public static readonly byte[] ExpansionKey = new byte[] { 0x54, 0x2F, 0xED, 0x67, 0x5D, 0xDD, 0x11, 0x2E, 0xB7, 0x40, 0x13, 0xE3, 0x29, 0xAB, 0x6D, 0x28, 0x3E, 0xD0, 0x4D, 0x51, 0xD3, 0x0B, 0x8F, 0x3C, 0x8F, 0x7D, 0x56, 0x0D, 0xB3, 0x5C, 0x5B, 0xDF, 0x8F, 0x05, 0x26, 0xE5, 0x9D, 0x36, 0xEE, 0x17, 0xF9, 0x40, 0xC3, 0x05, 0x6A, 0xF1, 0x1D, 0x2C, 0x79, 0xED, 0xC6, 0xE2, 0x0C, 0x15, 0x87, 0x93, 0xC1, 0x91, 0xE5, 0x8D, 0x44, 0x10, 0x98, 0x34, 0x08, 0x7A, 0xB6, 0x76, 0xAA, 0xB5, 0x34, 0x21, 0xEE, 0x72, 0x58, 0x27, 0x3F, 0x72, 0x5A, 0x93, 0x75, 0x78, 0x60, 0xC0, 0xA2, 0xF5, 0x52, 0x97, 0x9F, 0xF5, 0x28, 0x86, 0x23, 0x3A, 0xB4, 0xEA, 0xC3, 0x40, 0x12, 0x39, 0x92, 0xE2, 0x33, 0xD8, 0x7A, 0x39, 0x44, 0xA9, 0x5B, 0x58, 0x5F, 0x7C, 0xD9, 0xFC, 0x9F, 0xEF, 0x3F, 0x3A, 0x05, 0x5B, 0xA5, 0x4D, 0x1D, 0x63, 0x33, 0xD5, 0xEB, 0x43, 0x42, 0x79, 0x71, 0x85, 0x57, 0x92, 0xF8, 0xDE, 0xED, 0x7D, 0xE3, 0xF8, 0x33, 0x20, 0x2C, 0x92, 0x22, 0xE5, 0x6E, 0xCC, 0x1D, 0x21, 0x71, 0x04, 0xB8, 0xA7, 0x8D, 0x3B, 0xE6, 0x19, 0x53, 0x36, 0x1E, 0x14, 0x40, 0x12, 0xED, 0x7B, 0x85, 0x47, 0x8D, 0xD2, 0xCD, 0xF8, 0x4D, 0x71, 0xBC, 0x62 };

        private static int GF256Mul(int a, int b) => (a == 0 || b == 0) ? 0 : GF256Exp[(GF256Log[a] + GF256Log[b]) % 0xFF];

        private static byte[] DecryptKey(byte[] key)
        {
            for (int i = 0; i < 0x10; i++)
                key[i] = SBox[(i % 4 * 0x100) | key[i]];

            key = AES.Decrypt(key);

            for (int i = 0; i < 0x10; i++)
                key[i] ^= InitialKey[i];

            return key;
        }

        public static byte[] Decrypt(byte[] key, byte[] encryptedData, int blockSize)
        {
            long keySeed = -1;
            blockSize = Math.Min(blockSize, 0x1000);

            for (int i = 0; i < blockSize / 8; i++)
                keySeed ^= BitConverter.ToInt64(encryptedData, i * 8);

            key = DecryptKey(key);
            var keyLow = BitConverter.ToUInt64(key, 0);
            var keyHigh = BitConverter.ToUInt64(key, 8);
            var seed = keyLow ^ keyHigh ^ (ulong)keySeed ^ ConstKey;

            var rand = new MT19937_64(seed);
            var xorpad = new byte[0x1000];
            for (int i = 0; i < xorpad.Length / 8; i++)
                Buffer.BlockCopy(BitConverter.GetBytes(rand.Int63()), 0, xorpad, i * 8, 8);

            for (int i = 0; i < encryptedData.Length; i++)
                encryptedData[i] ^= xorpad[i & 0xFFF];

            return encryptedData;
        }
        private static void DescrambleChunk(byte[] input, int offset)
        {
            byte[] vector = new byte[0x10];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 0x10; j++)
                {
                    int k = Mhy0ShiftRow[(2 - i) * 0x10 + j];
                    int idx = j % 8;
                    vector[j] = (byte)(Mhy0Key[idx] ^ SBox[(j % 4 * 0x100) | GF256Mul(Mhy0Mul[idx], input[offset + k])]);
                }
                Buffer.BlockCopy(vector, 0, input, offset, 0x10);
            }
        }

        private static byte[] Descramble(byte[] input, ulong blockSize, ulong entrySize)
        {
            var roundedEntrySize = (int)((entrySize + 0xF) / 0x10 * 0x10);
            for (int i = 0; i < roundedEntrySize; i += 0x10)
                DescrambleChunk(input, i + 4);

            for (int i = 0; i < 4; i++)
                input[i] ^= input[i + 4];

            ulong currentEntry = (ulong)roundedEntrySize + 4;
            var finished = false;
            while (currentEntry < blockSize && !finished)
            {
                for (ulong i = 0; i < entrySize; i++)
                {
                    input[i + currentEntry] ^= input[i + 4];
                    if (i + currentEntry >= blockSize - 1)
                    {
                        finished = true;
                        break;
                    }
                }
                currentEntry += entrySize;
            }

            return input;
        }
        public static byte[] DescrambleHeader(byte[] input) => Descramble(input, 0x39, 0x1C);
        public static byte[] DescrambleEntry(byte[] input) => Descramble(input, (ulong)Math.Min(input.Length, 0x21), 8);
    }
}
