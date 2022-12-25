﻿using API_mokymai.Models;
using API_mokymai.Models.Dto;

namespace API_mokymai.Services.IServices
{
    public interface IBookWrapper
    {
        GetBookDto Bind(Book book);
        Object? Bind(Book book, char c);
        Book Bind(CreateBookDto book);
        Measure Bind(CreateMeasureDto measure);
        Reservation Bind(CreateReservationDto reservation, int measureId);
        Book Bind(UpdateBookDto book);
        public UpdateReservationDto Bind(Reservation reservation);
        public Reservation Bind(UpdateReservationDto reservation);

    }
}